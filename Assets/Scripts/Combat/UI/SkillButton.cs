using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    TeamScript targetTeam;
    Skill targetSkill;

    Image image;
    Image cooldown;
    Text skillText; 

	void Start ()
    {
        targetTeam = GameObject.FindObjectOfType<TeamScript>();

        image = gameObject.GetComponent<Image>();
        cooldown = gameObject.transform.Find("CooldownImage").GetComponent<Image>();
        skillText = gameObject.transform.Find("SkillArrow").transform.Find("SkillText").transform.Find("Text").GetComponent<Text>();
    }
	
	void Update ()
    {
        targetSkill = targetTeam.charPos[0].GetComponent<Skill>();

        switch (targetSkill.getType())
        {
            case 1:
                image.color = new Color(1.0f, 0.0f, 0.0f);
                break;
            case 2:
                image.color = new Color(0.0f, 0.7544947f, 1.0f);
                break;
            case 3:
                image.color = new Color(0.0f, 1.0f, 0.0f);
                break;
        }

        cooldown.fillAmount = targetSkill.getElapsed() / targetSkill.getCooldown();
        skillText.text = targetSkill.getName();
    }
}
