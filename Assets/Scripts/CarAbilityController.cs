using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarAbilityController : MonoBehaviour {

    public int ability = 0;

    public bool isAi = false;

    string useAbilityKey;

    public Transform bullet;
    public GameObject shield;

    public Transform respawnPos;

    public bool activeShield = false;
    private float cooldown = 5;
    private float shieldTimer = 0;

    //persuebehavior
    public Transform[] target;
    public float maxPrediction;

    public float abilityTimeout;

    public AudioSource shielddownaudio;
    public AudioSource Boxaudio;

    void Start()
    {
        AudioSource[] audios = GetComponents<AudioSource>();
        shielddownaudio = audios[1];
        //Boxaudio = audios[2];
        if (this.gameObject.tag == "racer1")
        {
            useAbilityKey = "e";
        }
        else if (this.gameObject.tag == "racer2")
        {
            useAbilityKey = "/";
        }
	}
	
	void Update () {
        AbilityTimeout();

        if (activeShield)
        {
            shield.transform.Rotate(0,2,0);
            shieldTimer += Time.deltaTime;
            if (shieldTimer > cooldown)
            {
                shieldDown();
            }
        } 
        if (!isAi)
        {
            if(this.gameObject.tag == "racer1" || this.gameObject.tag == "racer2" ){
                if (Input.GetKeyDown(useAbilityKey))
                {
                    switch (ability)
                    {
                        case 1:
                            shoot();
                            break;
                        case 2:
                            shieldUp();
                            break;
                    }
                }
            }
            else if(this.gameObject.tag == "racer3"){
                if (Input.GetKeyDown(KeyCode.Joystick1Button2))
                {
                    switch (ability)
                    {
                        case 1:
                            shoot();
                            break;
                        case 2:
                            shieldUp();
                            break;
                    }
                }
            }
            else if(this.gameObject.tag == "racer4"){
                if (Input.GetKeyDown(KeyCode.Joystick2Button2))
                {
                    switch (ability)
                    {
                        case 1:
                            shoot();
                            break;
                        case 2:
                            shieldUp();
                            break;
                    }
                }
            }
        }
        else{
            if(ability == 1){
                
                Vector3 direction = transform.rotation * Vector3.forward;
                Vector3 pos = transform.position + direction * 3f;
                Transform newObj = Instantiate(bullet, pos, transform.rotation) as Transform;
                newObj.GetComponent<Rigidbody>().AddForce(direction * 3000);
                ability = 0;
                abilityTimeout = 0;
            }
            if (ability == 2)
            {
                shieldUp();

            }
        }
    }

    public void shieldUp() {
        Debug.Log("Shield Up!");
        shield.SetActive(true);
        activeShield = true;
        ability = 0;
        abilityTimeout = 0;
    }
    public void shieldDown() {
        shielddownaudio.Play();
        Debug.Log("Shield Down!");
        shield.SetActive(false);
        shieldTimer = 0;
        activeShield = false;
    }

    public void shoot() {
        Vector3 direction = transform.rotation * Vector3.forward;
        Vector3 pos = transform.position + direction * 1.8f;
        Transform newObj = Instantiate(bullet, pos, transform.rotation) as Transform;
        newObj.GetComponent<Rigidbody>().AddForce(direction * 3000);
        ability = 0;
        abilityTimeout = 0;
    }

    public void destroy()
    {
        this.gameObject.SetActive(false);
        Vector3 direction = respawnPos.rotation * Vector3.forward;
        Vector3 pos = respawnPos.position + direction * 7f;
        transform.position = pos;
        transform.rotation = respawnPos.rotation;
        this.gameObject.SetActive(true);
    }

    void AbilityTimeout() {
        if(ability != 0){
            abilityTimeout += Time.deltaTime;
            if(abilityTimeout > 10) {
                abilityTimeout =0;
                ability = 0;
            }
        }
    }

    public void vaporation()
    {
        Debug.Log("evaporated");
        this.gameObject.SetActive(false);
        //this.GetComponent<Renderer>().enabled =false;
        Vector3 direction = respawnPos.rotation * Vector3.forward;
        Vector3 pos = respawnPos.position + direction * 7f;
        transform.position = pos;
        transform.rotation = respawnPos.rotation;

    }

    public void Dvapor()
    {
        Invoke("setactive", 3);
    }

    void setactive()
    {
        gameObject.SetActive(true);
    }
}
