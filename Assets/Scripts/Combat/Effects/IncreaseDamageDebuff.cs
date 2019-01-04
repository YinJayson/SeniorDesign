using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncreaseDamageDebuff : MonoBehaviour, Effect
{
    public float intensity;
    public float duration;

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
        icon.effect = "Incoming Damage +" + (intensity * 100.0f).ToString() + "%";
        icon.sprite = "IncreaseDamage";

        maxDuration = duration;

        effect();
    }

    void Update()
    {
        if (gameObject.GetComponent<CharacterScript>().pos != 0)
            expire();
    }

    public void effect()
    {
        target.damageMulti = target.damageMulti + (target.damageMulti * intensity);
    }

    public void expire()
    {
        target.damageMulti -= intensity;
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
