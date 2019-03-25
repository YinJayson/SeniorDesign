using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookBuff : MonoBehaviour, Effect
{
    public float intensity = 0.2f;
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
        target.multipliers.Add(intensity);
    }

    public void expire()
    {
        target.multipliers.Remove(intensity);

        icon.expire();
        Destroy(this);
    }
    public void onHit()
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
}
