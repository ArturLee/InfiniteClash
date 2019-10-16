using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;
using System.IO;

public class CarAI : MonoBehaviour {

	public int theAngle = 182;
 	public int segments = 12;
	string filename = "dataset5.txt";

	WaypointSystem waypointTracker;
	CarMovementNetwork net;
	StreamWriter sr;
	Car car;
	float timer = -3;
	bool offTrack = false;

	public bool isAi = false;

    private float offtracktimer = 0;
    CarAbilityController carabi;

	 void Start () {
		car = GetComponent<Car>();
        carabi = GetComponent<CarAbilityController>();
		waypointTracker = GetComponent<WaypointSystem>();
		net = GameObject.Find("NeuralNet").GetComponent<CarMovementNetwork>();
		waypointTracker.circuit = GameObject.Find("WaypointsCircuit").GetComponent<WaypointCircuit>();
		sr = File.CreateText(filename);
	}
	
	void Update () {
		GetData();
		if(offTrack){
            offtracktimer += Time.deltaTime;
            if (GetComponent<Car>().TopSpeed >= 30)
            {
                GetComponent<Car>().TopSpeed -= Time.deltaTime * 100;
            }
            if(offtracktimer>=5){
                carabi.destroy();
                offtracktimer = 0;
            }
        }
        else{
            GetComponent<Car>().TopSpeed = 120;
        }
	}

	void GetData() {
		float targetDistance = Vector3.Distance(transform.position, waypointTracker.progressPoint.position);

		string data = targetDistance + " ";

		int mask = (1 << 10);

        RaycastHit hit;

		Vector3 startPos = transform.position; // umm, start position !
		Vector3 targetPos = Vector3.zero; // variable for calculated end position
		
		int startAngle = Mathf.RoundToInt( -theAngle/2 ); // half the angle to the Left of the forward
		int finishAngle = Mathf.RoundToInt( theAngle/2 ); // half the angle to the Right of the forward
		
		// the gap between each ray (increment)
		int inc = Mathf.RoundToInt( theAngle / segments );

		float left = 0; 
		float right = 0;
		int x = 0;
		
		// step through and find each target point
		for ( int i = startAngle; i < finishAngle; i += inc ) // Angle from forward
		{
			targetPos = (Quaternion.Euler( 0, i, 0 ) * transform.forward ).normalized;   
			float dist = 10000;
			if (Physics.Raycast(transform.position, targetPos, out hit, Mathf.Infinity, mask))
			{
				Debug.DrawRay(transform.position, targetPos * hit.distance, Color.yellow);
				dist = hit.distance;
			}
			else
			{
				Debug.DrawRay(transform.position, targetPos * 1000, Color.white);
			}
			data += dist + " ";
			if (x == 0) {
				left = dist;
			} else if (x == 12) {
				right = dist;
			}
			x++;
		}
		
		//Debug.Log(left + right);
		if (left + right > 50) {
			Debug.Log("OFF-TRACK");
			offTrack = true;
		} else {
			offTrack = false;
		}

		
        /*if (Input.GetAxis("player1H") > 0){
			data += "0 0 1";
        } else if (Input.GetAxis("player1H") < 0) {
			data += "1 0 0";
        } else if (Input.GetAxis("player1H") == 0) {
			data += "0 1 0";
		}
		sr.WriteLine(data);*/
        

		if (isAi) {
			ClassifyData(data);	
		}
		
	}

	void ClassifyData(string data) {
		timer += Time.deltaTime;
		if (timer > 0.02f) {
			int actionID = net.ClassifyExample(data);
			if (actionID == 0) {
				Debug.Log ("Left");	
				car.steer = -1.5f;
				car.accel = -0.8f;
			} else if (actionID == 1) {
				Debug.Log ("Straight");
				car.steer = 0;
                car.accel = 0.5f;
			}else if (actionID == 2) {
				Debug.Log ("Right");
				car.steer = 1.5f;
                car.accel = -0.8f;
			}
			timer = 0;
		}
	}
}
