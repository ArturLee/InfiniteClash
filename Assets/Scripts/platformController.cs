using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformController : MonoBehaviour
{

    private bool enabled = true;
    private float cooldown = 5;
    private float timer = 0;

    public Transform trapp;
    public Transform spring;

    public AudioSource Boxaudio;

    public ParticleSystem smoke1;
    public ParticleSystem smoke2;
    void Start()
    {
        smoke1.GetComponent<ParticleSystem>();
        smoke1.Pause();
        smoke2.GetComponent<ParticleSystem>();
        smoke2.Pause();
        AudioSource[] audios = GetComponents<AudioSource>();
        Boxaudio = audios[0]; 
    }

    void Update()
    {
        if (!enabled)
        {
            timer += Time.deltaTime;
            if (timer > cooldown)
            {
                
                Debug.Log("Timer");
                timer = 0;
                enabled = true;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        triggerPlatform(other.gameObject);
    }

    void triggerPlatform(GameObject obj)
    {
        CarAbilityController cc = obj.transform.parent.transform.parent.GetComponent<CarAbilityController>();
        cc.respawnPos = gameObject.transform;
        if (enabled)
        {
            enabled = false;
            Debug.Log("TRIGGERED");
            var num = Random.Range(0, 3);
            switch (num)
            {
                case 0:
                    Vector3 direction = transform.rotation * Vector3.forward;
                    Vector3 pos = transform.position + direction * 8;
                    int tn = Random.Range(0,3);
                    if (tn == 0)
                    {
                        Transform newObject = Instantiate(trapp, new Vector3(pos.x, pos.y - 1, pos.z), transform.rotation) as Transform;
                        Debug.Log("trap");
                        Boxaudio.Play();
                    }
                    else if (tn == 1)
                    {
                        smoke1.Play();
                        obj.transform.parent.parent.GetComponent<Car>().inticarpos = obj.transform.parent.parent.position;
                        obj.transform.parent.parent.GetComponent<Car>().launch = true; 

                        Debug.Log("trap2");
                    }else if (tn == 2)
                    {
                        smoke2.Play();
                        obj.transform.parent.parent.GetComponent<CarAbilityController>().vaporation();
                        obj.transform.parent.parent.GetComponent<CarAbilityController>().Dvapor();
                    }
                    break;
                case 1:
                    Debug.Log("Attack");
                    cc.ability = 1;
                    break;
                case 2:
                    Debug.Log("Shield");
                    cc.ability = 2;
                    break;
            }
        }
    }

}
