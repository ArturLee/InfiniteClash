using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class RaceManager : MonoBehaviour
{
    public GameObject cars;
    WaypointSystem[] allCars;
    WaypointSystem[] carOrder;
    WaypointSystem player1, player2, player3, player4;
    Text pos1, lap1;
    Text pos2, lap2;
    Text pos3, lap3;
    Text pos4, lap4;
    public float raceTimer;
    float startTimer = -6;

    [SerializeField] private GameObject endGame;
    [SerializeField] private GameObject endGame1_2;
    [SerializeField] private GameObject endGame1_3;
    [SerializeField] private GameObject endGame2;
    [SerializeField] private GameObject endGame2_3;
    [SerializeField] private GameObject endGame3;
    [SerializeField] private GameObject endGame4;

    Text endpos1;
    Text endpos2;
    Text endpos3;
    Text endpos4;

    void Start()
    {
        pos1 = GameObject.FindGameObjectWithTag("player1canvas").GetComponentsInChildren<Text>()[0];
        lap1 = GameObject.FindGameObjectWithTag("player1canvas").GetComponentsInChildren<Text>()[1];

        allCars = cars.GetComponentsInChildren<WaypointSystem>();
        player1 = GameObject.FindGameObjectWithTag("racer1").GetComponent<WaypointSystem>();
        carOrder = allCars;
        if (GameInfo.Players >= 2)
        {
            player2 = GameObject.FindGameObjectWithTag("racer2").GetComponent<WaypointSystem>();
            pos2 = GameObject.FindGameObjectWithTag("player2canvas").GetComponentsInChildren<Text>()[0];
            lap2 = GameObject.FindGameObjectWithTag("player2canvas").GetComponentsInChildren<Text>()[1];
        }

        if (GameInfo.Players >= 3)
        {
            player3 = GameObject.FindGameObjectWithTag("racer3").GetComponent<WaypointSystem>();
            pos3 = GameObject.FindGameObjectWithTag("player3canvas").GetComponentsInChildren<Text>()[0];
            lap3 = GameObject.FindGameObjectWithTag("player3canvas").GetComponentsInChildren<Text>()[1];
        }

        if (GameInfo.Players >= 4)
        {
            player4 = GameObject.FindGameObjectWithTag("racer4").GetComponent<WaypointSystem>();
            pos4 = GameObject.FindGameObjectWithTag("player4canvas").GetComponentsInChildren<Text>()[0];
            lap4 = GameObject.FindGameObjectWithTag("player4canvas").GetComponentsInChildren<Text>()[1];
        }
        // set up the car objects
        InvokeRepeating("ManualUpdate", 0.5f, 0.5f);
    }

    void Update() {
        raceTimer += Time.deltaTime;
        if (raceTimer > 0) {
            StartRace();
        } 
        if (carOrder.Length > 0) {
            Array.Sort(carOrder, delegate(WaypointSystem x, WaypointSystem y) { return y.progressDistance.CompareTo(x.progressDistance); });
        }
        for (int i = 0; i < carOrder.Length; i++)
        {
            if (carOrder[i].GetComponent<WaypointSystem>().endedRace) {
                //carOrder[i].GetComponent<WaypointSystem>().progressDistance += 1000000;
                //finalPos[(Array.IndexOf(carOrder, carOrder[i]) + 1)] = carOrder[i];
                //Car car = carOrder[i].GetComponent<Car>();
                //car.receiveInput = false;
                //car.isAi = true;
                //carOrder[i].GetComponent<CarAI>().isAi = true;
                carOrder[i].gameObject.SetActive(false);
                //GameInfo.Points[]
            }
        }
    }

    public void ManualUpdate()
    {
        updatePlayer1UI();

        if (GameInfo.Players == 2)
        {
            updatePlayer2UI();
        } 
        else if (GameInfo.Players == 3)
        {
            updatePlayer2UI();
            updatePlayer3UI();
        }
        else if (GameInfo.Players == 4)
        {
            updatePlayer2UI();
            updatePlayer3UI();
            updatePlayer4UI();
        }
    }

    void updatePlayer1UI() {
        lap1.text = player1.currentLap.ToString() + "/3";
        pos1.text = (Array.IndexOf(carOrder, player1) + 1).ToString();
        if (player1.endedRace)
        {
            if (GameInfo.Players == 1)
            {
                endGame.SetActive(true);
            }
            else if (GameInfo.Players == 2){
                endGame1_2.SetActive(true);
            }
            else if (GameInfo.Players >= 3)
            {
                endGame1_3.SetActive(true);
            }
            endpos1 = GameObject.FindGameObjectWithTag("endRaceP1").GetComponentsInChildren<Text>()[0];
            endpos1.text ="#" + (Array.IndexOf(carOrder, player1) + 1).ToString() + " - Place!";
        }
    }

    void updatePlayer2UI() {
        lap2.text = player2.currentLap.ToString() + "/3";
        pos2.text = (Array.IndexOf(carOrder, player2) + 1).ToString();
        if (player2.endedRace)
        {
            if (GameInfo.Players == 2)
            {
                endGame2.SetActive(true);
            }
            else if (GameInfo.Players >= 3)
            {
                endGame2_3.SetActive(true);
            }
            endGame2.SetActive(true);
            endpos2 = GameObject.FindGameObjectWithTag("endRaceP2").GetComponentsInChildren<Text>()[0];
            endpos2.text = "#" + (Array.IndexOf(carOrder, player2) + 1).ToString() + " - Place!";
        }
    }

    void updatePlayer3UI() {
        lap3.text = player3.currentLap.ToString() + "/3";
        pos3.text = (Array.IndexOf(carOrder, player3) + 1).ToString();
        if (player3.endedRace)
        {
            endGame3.SetActive(true);
            endpos3 = GameObject.FindGameObjectWithTag("endRaceP3").GetComponentsInChildren<Text>()[0];
            endpos3.text = "#" + (Array.IndexOf(carOrder, player3) + 1).ToString() + " - Place!";
        }
    }

    void updatePlayer4UI() {
        lap4.text = player4.currentLap.ToString() + "/3";
        pos4.text = (Array.IndexOf(carOrder, player4) + 1).ToString();
        if (player4.endedRace)
        {
            endGame4.SetActive(true);
            endpos4 = GameObject.FindGameObjectWithTag("endRaceP4").GetComponentsInChildren<Text>()[0];
            endpos4.text = "#" + (Array.IndexOf(carOrder, player4) + 1).ToString() + " - Place!";
        }
    }

    void StartRace() {
        for (int i = 0; i < allCars.Length; i++)
        {
            //allCars[i].GetComponent<Car>().startRacing = true;
        }
    }
}