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
        bar = gameObject.transform.GetChild(0).GetComponent<Image>();
    }

	void Update()
    {
        bar.fillAmount = target.actionBar / 100.0f;
        gameObject.transform.position = new Vector2(target.transform.position.x, target.transform.position.y - 25);
	}
}
