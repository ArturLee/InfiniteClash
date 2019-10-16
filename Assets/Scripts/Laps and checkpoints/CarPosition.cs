using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CarPosition : MonoBehaviour
{
    public Transform[] checkPointArray;
    public int currentWaypoint;
    public int currentLap;
    public int cposition;
    public Transform lastWaypoint;
    public int nbWaypoint; //Set the amount of Waypoints

    private static int WAYPOINT_VALUE = 100;
    private static int LAP_VALUE = 10000;
    private int cpt_waypoint = 0;

    // Use this for initialization
    void Start()
    {
        currentWaypoint = 0;
        currentLap = 1;
        cpt_waypoint = 0;
    }

    public void OnTriggerEnter(Collider other)
    {
        string otherTag = other.gameObject.name;
        //Debug.Log(other.gameObject.name);
        currentWaypoint = System.Convert.ToInt32(other.gameObject.name);
        if (currentWaypoint == 1 && cpt_waypoint == nbWaypoint)
        { // completed a lap, so increase currentLap;
            currentLap++;
            cpt_waypoint = 0;
        }
        if (cpt_waypoint == currentWaypoint - 1)
        {
            lastWaypoint = other.transform;
            cpt_waypoint++;
        }
    }

    public float GetDistance()
    {
        return (transform.position - lastWaypoint.position).magnitude + currentWaypoint * WAYPOINT_VALUE + currentLap * LAP_VALUE;
    }

    public int GetCarPosition(CarPosition[] allCars)
    {
        float distance = GetDistance();
        int position = 1;
        foreach (CarPosition car in allCars)
        {
            if (car.GetDistance() > distance)
                position++;
            //Debug.Log(gameObject.name+ "Position " + position);
        }
        cposition = position;
        return position;

    }
}
