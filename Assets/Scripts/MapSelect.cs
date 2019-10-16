using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapSelect : MonoBehaviour
{

    public Toggle[] buttons;

    void Start()
    {

    }

    void Update()
    {
        foreach (Toggle t in buttons)
        {
            if (t.isOn)
            {
                Color newCol;
                string htmlValue = "#FFFFFFFF";
                if (ColorUtility.TryParseHtmlString(htmlValue, out newCol)) t.gameObject.GetComponentsInChildren<Image>()[0].color = newCol;
            }
            else
            {
                Color newCol;
                string htmlValue = "#2F2F2FFF";
                if (ColorUtility.TryParseHtmlString(htmlValue, out newCol)) t.gameObject.GetComponentsInChildren<Image>()[0].color = newCol;
            }
        }
    }

    public void GoToRace()
    {
        int map = 0;
        if (buttons[0].isOn)
        {
            GameInfo.Map = 0;
            map = 0;
        }
        else if (buttons[1].isOn)
        {
            GameInfo.Map = 1;
            map = 1;
        }

        switch (map)
        {
            case 0:
                SceneManager.LoadScene("Track 1");
                break;
            case 1:
                SceneManager.LoadScene("Track 2");
                break;
        }

    }
}
