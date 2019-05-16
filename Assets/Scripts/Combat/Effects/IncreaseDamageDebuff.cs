using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IncreaseDamageDebuff : MonoBehaviour, Effect
{
    public float intensity;
    public float duration;
    public bool expireOnHit = false;  // Default: Expires on hit false

    public float maxDuration;
    EffectIcon icon;
    CharacterScript target;
    GameObject targetEffectBar;

    void Start()
    {
        // Default: Intensity = 10%
        if (intensity == 0)
            intensity = 0.1f;

        target = gameObject.GetComponent<CharacterScript>();
        targetEffectBar = target.transform.GetChild(2).gameObject;
        icon = Instantiate(Resources.Load<GameObject>("Prefabs/EffectIcon") as GameObject, new Vector2(targetEffectBar.transform.position.x - 15, targetEffectBar.transform.position.y), Quaternion.identity, targetEffectBar.transform).GetComponent<EffectIcon>();
        icon.target = this;
        icon.effect = "Incoming Damage +" + (intensity * 100.0f).ToString() + "%";
        icon.sprite = "IncreaseDamage";

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
        target.dmgMultis.Add(-intensity);
    }
    public void expire()
    {
        target.dmgMultis.Remove(-intensity);
        icon.expire();
        Destroy(this);
    }
    public void onHit()
    {
        if (expireOnHit)
            expire();
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
