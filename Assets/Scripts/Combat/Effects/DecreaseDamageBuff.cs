using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecreaseDamageDebuff : MonoBehaviour, Effect
{
    public float intensity;
    public float duration;
    public float originalMulti;

    public float maxDuration;
    EffectIcon icon;
    CharacterScript target;
    GameObject targetEffectBar;

    void Start()
    {
        if (intensity == 0)
            intensity = 0.1f;

        target = gameObject.GetComponent<CharacterScript>();
        targetEffectBar = target.transform.GetChild(2).gameObject;
        icon = Instantiate(Resources.Load<GameObject>("Icons/EffectIcon") as GameObject, new Vector2(targetEffectBar.transform.position.x - 15, targetEffectBar.transform.position.y), Quaternion.identity, targetEffectBar.transform).GetComponent<EffectIcon>();
        icon.target = this;
        icon.effect = "Incoming Damage -" + (intensity * 100.0f).ToString() + "%";
        icon.sprite = "DecreaseDamage";

        maxDuration = duration;

        effect();
    }

    void Update()
    {
        duration -= Time.deltaTime;

        if (duration <= 0.0f)
            expire();
    }

    public void effect()
    {
        originalMulti = target.damageMulti;
        target.damageMulti = target.damageMulti - (target.damageMulti * intensity);
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
