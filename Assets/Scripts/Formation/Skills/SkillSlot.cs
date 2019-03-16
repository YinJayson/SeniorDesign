using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour
{
    Skill skillToDisplay;

    void Start()
    {
        displaySkill();
    }

    void Update()
    {
        displaySkill();
    }

    public void displaySkill()
    {
        skillToDisplay = gameObject.GetComponent<Skill>();
        gameObject.transform.Find("SkillNameText").GetComponent<Text>().text = skillToDisplay.getName();
        gameObject.transform.Find("DescriptionText").GetComponent<Text>().text = skillToDisplay.getDescription();
        gameObject.transform.Find("CooldownText").GetComponent<Text>().text = "Cooldown: " + skillToDisplay.getCooldown().ToString();
    }
}
