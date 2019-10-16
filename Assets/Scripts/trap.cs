using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour {

    private float cooldown = 3;
    private float timer = 0;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer > cooldown)
        {
            Debug.Log("Timer");
            timer = 0;
            Destroy(gameObject);
        }
    }
}
