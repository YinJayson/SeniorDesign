using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    TeamScript targetTeam;
    Skill targetSkill;

    public Image type;
    public Image cooldown;

	void Start ()
    {
        type = gameObject.GetComponent<Image>();
        cooldown = gameObject.transform.GetChild(1).GetComponent<Image>();

        targetTeam = GameObject.FindObjectOfType<TeamScript>();
        //targetSkill = targetTeam.charPos[0].GetComponent<Skill>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        targetSkill = targetTeam.charPos[0].GetComponent<Skill>();

        switch (targetSkill.getType())
        {
            case 1:
                type.color = new Color(1.0f, 0.0f, 0.0f);
                break;
            case 2:
                type.color = new Color(0.0f, 0.0f, 1.0f);
                break;
            case 3:
                type.color = new Color(0.0f, 1.0f, 0.0f);
                break;
        }

        cooldown.fillAmount = targetSkill.getElapsed() / targetSkill.getCooldown();
    }
}
