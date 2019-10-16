using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUI : MonoBehaviour {

    public string tag;
    CarAbilityController target;
    public Sprite nothingPng, attackPng, shieldPng;
    private Image abilityUI;

    void Start () {
        abilityUI = GetComponent<Image>();
        abilityUI.sprite = nothingPng;
    }

	void Update () {
        if (target == null) {
            target = GameObject.FindGameObjectWithTag(tag).GetComponent<CarAbilityController>();
        }

        switch (target.ability)
        {
            case 0:
                abilityUI.sprite = nothingPng;
                break;
            case 1:
                abilityUI.sprite = attackPng;
                break;
            case 2:
                abilityUI.sprite = shieldPng;
                break;
        }
    }
}
