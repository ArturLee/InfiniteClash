using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {

	private float cooldown = 5;
    private float timer = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
        if (timer > cooldown)
        {
           Destroy(gameObject);
        }
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.name == "BoxColliders") {
			CarAbilityController cc = other.transform.parent.transform.parent.GetComponent<CarAbilityController>();
            Debug.Log(other.gameObject.layer);
            if (!cc.activeShield) {
                cc.destroy();
            } else {
				cc.shieldDown();
			}
			Destroy(gameObject);
		}
    }
}
