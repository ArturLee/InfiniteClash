using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

	public void singlePlayer() {
		GameInfo.Players = 1;
		GameInfo.Laps = 3;
		SceneManager.LoadScene("CarSelect");
	}

	public void multiPlayer() {
		GameInfo.Laps = 3;
		SceneManager.LoadScene("PlayersSelect");
	}

}
