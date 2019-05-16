using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StunDebuff : MonoBehaviour, Effect
{
    public float duration;

    float maxDuration;
    EffectIcon icon;
    CharacterScript target;
    GameObject targetEffectBar;

    void Start()
    {
        if (duration == 0)
            duration = 3.0f;

        target = gameObject.GetComponent<CharacterScript>();
        targetEffectBar = target.transform.Find("EffectBar").gameObject;
        icon = Instantiate(Resources.Load<GameObject>("Prefabs/EffectIcon") as GameObject, new Vector2(targetEffectBar.transform.position.x - 15, targetEffectBar.transform.position.y), Quaternion.identity, targetEffectBar.transform).GetComponent<EffectIcon>();
        icon.target = this;

        icon.effect = "Stunned";
        icon.sprite = "StunDebuff";

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
        target.stunned = true;
    }
    public void expire()
    {
        target.stunned = false;

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
        return 1.0f;
    }
}
