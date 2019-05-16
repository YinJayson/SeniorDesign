using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCooldownIcon : MonoBehaviour
{
    public Skill skill;
    Image background;

	void Start ()
    {
        skill = gameObject.transform.parent.GetComponent<Skill>();
        if (gameObject.transform.GetChild(0) != null)
            background = gameObject.transform.GetChild(0).GetComponent<Image>();
        gameObject.transform.localPosition = new Vector2(0, -35);
	}
	
	void Update ()
    {
        gameObject.GetComponent<Image>().fillAmount = skill.getElapsed() / skill.getCooldown();
        if (background != null)
            background.fillAmount = gameObject.GetComponent<Image>().fillAmount;

        if (skill.getReady())
            Destroy(gameObject);
	}
}
