using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockedDebuff : MonoBehaviour, Effect
{
    public float intensity = 0.2f;
    public float duration;
    //public bool expiresOnHit = true;  // Blocked debuff only lasts for one hit

    public float maxDuration;
    EffectIcon icon;
    CharacterScript target;
    GameObject targetEffectBar;

    void Start()
    {
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
        // Only applies if remaining in front
        if (gameObject.GetComponent<CharacterScript>().pos != 0)
            expire();
    }

    public void effect()
    {
        target.multipliers.Add(-intensity);
    }

    public void expire()
    {
        target.multipliers.Remove(-intensity);
        icon.expire();
        Destroy(this);
    }
    public void onHit()
    {
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
