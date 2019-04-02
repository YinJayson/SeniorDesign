using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour
{
    TeamScript targetTeam;

    public Image image;
    public Image background;

    bool physical;


	// Use this for initialization
	void Start ()
    {
        targetTeam = GameObject.FindObjectOfType<TeamScript>();

        image = gameObject.transform.GetChild(0).GetComponent<Image>();
        background = gameObject.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        physical = targetTeam.charPos[0].GetComponent<CharacterScript>().basicAttackType;

        if (physical)
        {
            image.sprite = Resources.Load<Sprite>("Images/PhysicalAttack") as Sprite;
            background.color = new Color(1.0f, 0.06132086f, 0.06132086f);
        }
        else
        {
            image.sprite = Resources.Load<Sprite>("Images/MagicAttack") as Sprite;
            background.color = new Color(0.0f, 1.0f, 1.0f);
        }
	}
}
