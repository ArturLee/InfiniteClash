using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSelect : MonoBehaviour {

    public Toggle[] buttons;
    int players = GameInfo.Players;

    void Start () {
        
    }


    void Update () {
        foreach (Toggle t in buttons)
        {
            if (t.isOn) {
                Color newCol;
                string htmlValue = "#FFFFFF44";
                if (ColorUtility.TryParseHtmlString(htmlValue, out newCol)) t.gameObject.GetComponentsInChildren<Image>()[0].color = newCol;
            } else
            {
                Color newCol;
                string htmlValue = "#2F2F2F44";
                if (ColorUtility.TryParseHtmlString(htmlValue, out newCol)) t.gameObject.GetComponentsInChildren<Image>()[0].color = newCol;
            }
        }
    }

    public void GoToCarSelect() {
		int players = 0;
        if(buttons[0].isOn)
        {
            GameInfo.Players = 2;
			players = 2;
        }
        else if(buttons[1].isOn)
        {
            GameInfo.Players = 3;
			players = 3;
        }
		else if(buttons[2].isOn)
        {
            GameInfo.Players = 4;
			players = 4;
        }

        SceneManager.LoadScene("MapSelect");

    }
}
