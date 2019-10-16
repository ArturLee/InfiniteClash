using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarSelect : MonoBehaviour {

    public Toggle[] cars;
    int players = GameInfo.Players;

    void Start () {
        
    }


    void Update () {
        foreach (Toggle t in cars)
        {
            if (t.isOn) {
                t.gameObject.GetComponentsInChildren<Image>()[0].color = Color.white;
            } else
            {
                t.gameObject.GetComponentsInChildren<Image>()[0].color = Color.black;
            }
        }
    }

    public void startRace() {
        if(cars[0].isOn)
        {
            GameInfo.Cars[0] = 1;
        }
        else
        {
            GameInfo.Cars[0] = 2;
        }
        if (players == 2)
        {
            if (cars[2].isOn)
            {
                GameInfo.Cars[1] = 1;
            }
            else
            {
                GameInfo.Cars[1] = 2;
            }
        }
        if (players >= 3)
        {
            if (cars[4].isOn)
            {
                GameInfo.Cars[2] = 1;
            }
            else
            {
                GameInfo.Cars[2] = 2;
            }

            if (cars[6].isOn)
            {
                GameInfo.Cars[3] = 1;
            }
            else
            {
                GameInfo.Cars[3] = 2;
            }
        }
        
        SceneManager.LoadScene("MapSelect");
    }
}
