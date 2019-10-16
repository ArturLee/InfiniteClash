using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RaceController : MonoBehaviour {

    public Transform spawnpoints;
	public GameObject onePlayerView, twoPlayerView, plusPlayerView;
	GameObject player1, player2, player3, player4;
    public Transform car1, car2, car3, car4, carai;
    int players;

	void Start () {

        Transform[] points = spawnpoints.GetComponentsInChildren<Transform>();

        foreach (Transform t in points) {
            Debug.Log(t.position);
        }

        players = GameInfo.Players;
		switch (players)
            {
                case 1:
                    InstantiatePlayerCar(player1, "racer1", car1, points[1], false);
                    InstantiatePlayerCar(player1, "racer2", carai, points[2], true);
                    InstantiatePlayerCar(player1, "racer3", carai, points[3], true);
                    InstantiatePlayerCar(player1, "racer4", carai, points[4], true);
                    onePlayerView.SetActive(true);
                    twoPlayerView.SetActive(false);
                    plusPlayerView.SetActive(false);
                    break;
                case 2:
                    InstantiatePlayerCar(player1, "racer1", car1, points[1], false);
                    InstantiatePlayerCar(player2, "racer2", car2, points[2], false);
                    InstantiatePlayerCar(player1, "racer3", carai, points[3], true);
                    InstantiatePlayerCar(player1, "racer4", carai, points[4], true);
                    onePlayerView.SetActive(false);
                    twoPlayerView.SetActive(true);
                    plusPlayerView.SetActive(false);
                    break;
                case 3:
                    InstantiatePlayerCar(player1, "racer1", car1, points[1], false);
                    InstantiatePlayerCar(player2, "racer2", car2, points[2], false);
                    InstantiatePlayerCar(player3, "racer3", car3, points[3], false);
                    InstantiatePlayerCar(player1, "racer4", carai, points[4], true);
                    onePlayerView.SetActive(false);
                    twoPlayerView.SetActive(false);
                    plusPlayerView.SetActive(true);
                    break;
                case 4:
                    InstantiatePlayerCar(player1, "racer1", car1, points[1], false);
                    InstantiatePlayerCar(player2, "racer2", car2, points[2], false);
                    InstantiatePlayerCar(player3, "racer3", car3, points[3], false);
                    InstantiatePlayerCar(player4, "racer4", car4, points[4], false);
                    onePlayerView.SetActive(false);
                    twoPlayerView.SetActive(false);
                    plusPlayerView.SetActive(true);
                    break;
            }
	}

    void InstantiatePlayerCar(GameObject player, string tag, Transform carObj, Transform point, bool isAi) {
        Vector3 direction = point.transform.rotation * Vector3.forward;
        Vector3 pos = point.transform.position + direction * 1.8f;
        Transform newObj = Instantiate(carObj, pos, point.transform.rotation) as Transform;
        newObj.parent = GameObject.Find("Cars").transform;
        newObj.tag = tag;
        //newObj.GetComponent<Car>().isAi = isAi;
        //newObj.GetComponent<CarAI>().isAi = isAi;
        newObj.GetComponent<CarAbilityController>().isAi = isAi;
        player = newObj.gameObject;
    }
	
	void Update () {
		if (Input.GetKeyDown("r")) {
            Application.LoadLevel(Application.loadedLevel);
            //SceneManager.LoadScene("Track 1");
        }
	}
}
