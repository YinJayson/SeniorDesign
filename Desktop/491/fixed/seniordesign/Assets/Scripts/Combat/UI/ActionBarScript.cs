using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBarScript : MonoBehaviour
{
    //public CharacterScript target;
    CharacterScript target;

    Image bar;

    void Start()
    {
        target = gameObject.GetComponentInParent<CharacterScript>();
        bar = gameObject.transform.Find("Filling").GetComponent<Image>();
    }

	void Update()
    {
        bar.fillAmount = target.actionBar / 100.0f;
	}
}
