using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    //public CharacterScript target;
    CharacterScript target;

    Image bar;
    Text text;

    void Start()
    {
        target = gameObject.GetComponentInParent<CharacterScript>();
        bar = gameObject.transform.Find("HealthBarFilling").GetComponent<Image>();
        text = gameObject.transform.Find("HealthBarText").GetComponent<Text>();
    }

	void Update ()
    {
        bar.fillAmount = (float)target.HP / (float)target.maxHP;
        text.text = target.HP + " / " + target.maxHP;
	}
}
