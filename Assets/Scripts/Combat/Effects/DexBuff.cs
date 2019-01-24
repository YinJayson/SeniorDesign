using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DexBuff : MonoBehaviour, Effect
{
    public int intensity;
    public float duration;

    float maxDuration;
    EffectIcon icon;
    CharacterScript target;
    GameObject targetEffectBar;

    void Start()
    {
        if (intensity == 0)
            intensity = 5;
        if (duration == 0)
            duration = 5.0f;

        target = gameObject.GetComponent<CharacterScript>();
        targetEffectBar = target.transform.GetChild(2).gameObject;
        icon = Instantiate(Resources.Load<GameObject>("Icons/EffectIcon") as GameObject, new Vector2(targetEffectBar.transform.position.x - 15, targetEffectBar.transform.position.y), Quaternion.identity, targetEffectBar.transform).GetComponent<EffectIcon>();
        icon.target = this;
        icon.effect = "Dex +" + intensity.ToString();
        icon.sprite = "DexBuff";

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
        target.dex += intensity;
    }

    public void expire()
    {
        if (target != null)
            target.dex -= intensity;

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
