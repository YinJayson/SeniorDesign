using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    TeamScript targetTeam;
    Skill targetSkill;

    public Image image;
    public Image cooldown;

	void Start ()
    {
        targetTeam = GameObject.FindObjectOfType<TeamScript>();

        image = gameObject.GetComponent<Image>();
        cooldown = gameObject.transform.GetChild(1).GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        targetSkill = targetTeam.charPos[0].GetComponent<Skill>();

        switch (targetSkill.getType())
        {
            case 1:
                image.color = new Color(1.0f, 0.0f, 0.0f);
                break;
            case 2:
                image.color = new Color(0.0f, 0.0f, 1.0f);
                break;
            case 3:
                image.color = new Color(0.0f, 1.0f, 0.0f);
                break;
        }

        cooldown.fillAmount = targetSkill.getElapsed() / targetSkill.getCooldown();
    }
}
