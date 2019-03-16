using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCooldownIcon : MonoBehaviour
{
    public float cooldown;
    public CharacterScript target;
    float elapsedTime;
    Image background;

	void Start ()
    {
        if (gameObject.transform.GetChild(0) != null)
            background = gameObject.transform.GetChild(0).GetComponent<Image>();
        elapsedTime = cooldown;
	}
	
	void Update ()
    {
        gameObject.transform.position = new Vector2(target.transform.position.x, target.transform.position.y - 35);
        gameObject.GetComponent<Image>().fillAmount = elapsedTime / cooldown;
        if (background != null)
            background.fillAmount = gameObject.GetComponent<Image>().fillAmount;

        elapsedTime -= Time.deltaTime;

        if (elapsedTime <= 0.0f)
            Destroy(gameObject);
	}
}
