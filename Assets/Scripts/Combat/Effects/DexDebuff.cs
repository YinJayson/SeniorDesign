﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DexDebuff : MonoBehaviour, Effect
{
    public float intensity;
    public float duration;

    float maxDuration;
    EffectIcon icon;
    CharacterScript target;
    GameObject targetEffectBar;

	void Start()
    {
        if (intensity == 0)
            intensity = 0.1f;
        if (duration == 0)
            duration = 10.0f;

        target = gameObject.GetComponent<CharacterScript>();
        targetEffectBar = target.transform.Find("EffectBar").gameObject;
        icon = Instantiate(Resources.Load<GameObject>("Prefabs/EffectIcon") as GameObject, new Vector2(targetEffectBar.transform.position.x - 15, targetEffectBar.transform.position.y), Quaternion.identity, targetEffectBar.transform).GetComponent<EffectIcon>();
        icon.target = this;
        icon.effect = "Dex -" + (intensity * 100.0f).ToString() + "%";
        icon.sprite = "DexDebuff";

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
        target.dex -= Mathf.RoundToInt(target.baseDex * intensity);
    }

    public void expire()
    {
        if (target != null)
            target.dex += Mathf.RoundToInt(target.baseDex * intensity);

        icon.expire();
        Destroy(this);
    }
    public void onHit()
    {

    }
    public void setMaxDuration(float maxDuration)
    {
        this.maxDuration = maxDuration;
    }
    public void setDuration(float duration)
    {
        this.duration = duration;
    }
    public void setIntensity(float intensity)
    {
        this.intensity = intensity;
    }
    public float getMaxDuration()
    {
        return maxDuration;
    }
    public float getDuration()
    {
        return duration;
    }
    public float getIntensity()
    {
        return intensity;
    }
}
