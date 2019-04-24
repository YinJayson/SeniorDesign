using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookBuff : MonoBehaviour, Effect
{
    public float intensity = 0.25f;
    public float duration = 10.0f;

    public float maxDuration = 10.0f;

    EffectIcon icon;
    GameObject skillBook;
    CharacterScript target;
    GameObject targetEffectBar;

    void Start()
    {
        target = gameObject.GetComponent<CharacterScript>();
        targetEffectBar = target.transform.Find("EffectBar").gameObject;
        icon = Instantiate(Resources.Load<GameObject>("Icons/EffectIcon") as GameObject, new Vector2(targetEffectBar.transform.position.x - 15, targetEffectBar.transform.position.y), Quaternion.identity, targetEffectBar.transform).GetComponent<EffectIcon>();
        icon.target = this;
        icon.effect = "Incoming Damage -" + (intensity * 100.0f).ToString() + "%";
        icon.sprite = "DecreaseDamage";

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
        target.dmgMultis.Add(intensity);
    }

    public void expire()
    {
        target.dmgMultis.Remove(intensity);

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
