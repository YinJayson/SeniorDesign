using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplyDamage : MonoBehaviour
{
    /* Damage related */
    public int dmg;
    public float critRate;
    public float critDmg;
    public bool physical;
    public CharacterScript source;
    int dmgToApply;
    bool crit;

    /* Effect related */
    public float intensity;
    public float duration;

    /* Multihit related */
    bool firstHit;      // Applies only to multihit. Damage is calculated at start of attack

    CharacterScript charScript;

    void Start()
    {
        charScript = gameObject.transform.parent.GetComponent<CharacterScript>();
        firstHit = true;
    }

    public void damage()
    {
        float dmgReduction = charScript.dmgReduction;

        if (physical)
        {
            int defense = charScript.defense;

            if (Random.Range(0.0f, 1.0f) <= critRate)    // Apply crit
            {
                dmgToApply = Mathf.RoundToInt(((dmg + Mathf.RoundToInt(dmg * critDmg))) * (1 - dmgReduction) - defense);
                crit = true;
            }
            else
            {
                dmgToApply = Mathf.RoundToInt(dmg * (1 - dmgReduction) - defense);
                crit = false;
            }
        }
        else
        {
            int resist = charScript.resist;

            if (Random.Range(0.0f, 1.0f) <= critRate)    // Apply crit
            {
                dmgToApply = Mathf.RoundToInt(((dmg + Mathf.RoundToInt(dmg * critDmg))) * (1 - dmgReduction) - resist);
                crit = true;
            }
            else
            {
                dmgToApply = Mathf.RoundToInt(dmg * (1 - dmgReduction) - resist);
                crit = false;
            }
        }

        charScript.applyDamage(dmgToApply, physical, crit, source);
    }
    public void multiHitDamage(float multiplier)
    {
        if (!firstHit)
            charScript.applyDamage(dmgToApply * multiplier, physical, crit, source);

        if (multiplier == 0.0f)
            multiplier = 1.0f;

        float dmgMulti = charScript.dmgReduction;

        if (physical)
        {
            int defense = charScript.defense;

            if (Random.Range(0.0f, 1.0f) <= critRate)    // Apply crit
            {
                dmgToApply = Mathf.RoundToInt(((dmg + Mathf.RoundToInt(dmg * critDmg))) * dmgMulti) - defense;
                crit = true;
            }
            else
            {
                dmgToApply = Mathf.RoundToInt(dmg * dmgMulti) - defense;
                crit = false;
            }
        }
        else
        {
            int resist = charScript.resist;

            if (Random.Range(0.0f, 1.0f) <= critRate)    // Apply crit
            {
                dmgToApply = Mathf.RoundToInt(((dmg + Mathf.RoundToInt(dmg * critDmg))) * dmgMulti) - resist;
                crit = true;
            }
            else
            {
                dmgToApply = Mathf.RoundToInt(dmg * dmgMulti) - resist;
                crit = false;
            }
        }

        firstHit = false;
        charScript.applyDamage(dmgToApply * multiplier, physical, crit, source);
    }
    public void applyEffect(string effectName)
    {
        Effect effect;

        switch(effectName)
        {
            case ("stun"):
                {
                    effect = charScript.gameObject.AddComponent<StunDebuff>();
                    effect.setDuration(duration);
                    effect.setIntensity(intensity);
                    break;
                }
        }
    }
}
