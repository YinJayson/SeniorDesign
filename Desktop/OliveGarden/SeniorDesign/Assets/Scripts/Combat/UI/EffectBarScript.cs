using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectBarScript : MonoBehaviour
{
    //public CharacterScript target;
    CharacterScript target;

    Image[] icons;

    void Start()
    {
        target = gameObject.GetComponentInParent<CharacterScript>();
    }

    void Update()
    {
        gameObject.transform.position = new Vector2(target.transform.position.x, target.transform.position.y + 60);

        icons = gameObject.GetComponentsInChildren<Image>();

        for (int i = 1; i < icons.Length; i++)              // i starts at 1 because icons[0] is the parent image
        {
            icons[i].GetComponent<MoveToLocalPosition>().x = (i - (Mathf.Floor(((float)i - 1.0f) / 4.0f) * 4)) * 10 - 25;
            icons[i].GetComponent<MoveToLocalPosition>().y = Mathf.Floor(((float)i - 1.0f) / 4.0f) * 10;
        }


        //icons[i].GetComponent<Transform>().localPosition = new Vector2((i - (Mathf.Floor(((float)i - 1.0f) / 4.0f) * 4)) * 10 - 25, Mathf.Floor(((float) i - 1.0f) / 4.0f) * 10);
    }
}