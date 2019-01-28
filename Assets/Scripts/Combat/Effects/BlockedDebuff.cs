using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockedDebuff : MonoBehaviour, Effect
{
    public float intensity = 0.2f;
    public float duration;
    public float originalMulti;

    public float maxDuration;
    EffectIcon icon;
    CharacterScript target;
    GameObject targetEffectBar;

    int health;

    void Start()
    {
        target = gameObject.GetComponent<CharacterScript>();
        targetEffectBar = target.transform.GetChild(2).gameObject;
        icon = Instantiate(Resources.Load<GameObject>("Icons/EffectIcon") as GameObject, new Vector2(targetEffectBar.transform.position.x - 15, targetEffectBar.transform.position.y), Quaternion.identity, targetEffectBar.transform).GetComponent<EffectIcon>();
        icon.target = this;
        icon.effect = "Incoming Damage +" + (intensity * 100.0f).ToString() + "%";
        icon.sprite = "IncreaseDamage";

        maxDuration = duration;
        health = target.HP;
        effect();
    }

    void Update()
    {
        // Only applies if remaining in front
        if (gameObject.GetComponent<CharacterScript>().pos != 0)
            expire();

        // Only applies for one hit
        if (target.HP < health)
            expire();
        health = target.HP;
    }

    public void effect()
    {
        originalMulti = target.damageMulti;
        target.damageMulti = target.damageMulti + (target.damageMulti * intensity);
    }

    public void expire()
    {
        target.damageMulti *= originalMulti / target.damageMulti;
        icon.expire();
        Destroy(this);
    }

    public float getMaxDuration()
    {
        return maxDuration;
    }

    public float getDuration()
    {
        return duration;
    }
}
