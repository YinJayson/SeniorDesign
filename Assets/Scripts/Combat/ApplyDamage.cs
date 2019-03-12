using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplyDamage : MonoBehaviour
{
    public int dmg;
    public float critRate;
    public float critDmg;
    public bool physical;

    int dmgToApply;
    bool crit;

    CharacterScript charScript;

    void Start()
    {
        charScript = gameObject.transform.parent.GetComponent<CharacterScript>();

        // Calculates Damage
        float dmgMulti = charScript.damageMulti;

        if(physical)
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

    }

    public void damage(float multiplier)
    {
        if (multiplier == 0.0f)
            multiplier = 1.0f;

        charScript.applyDamage(dmgToApply * multiplier, physical, crit);

        /*
        if (physical)    // If physical attack
            if (Random.Range(0.0f, 1.0f) <= critRate)    // Apply crit
            {
                dmgToApply = Mathf.RoundToInt(((dmg + Mathf.RoundToInt(dmg * critDmg))) * charScript.damageMulti);
                charScript.applyCritDamage(dmgToApply, true);
            }
            else
            {
                dmgToApply = Mathf.RoundToInt(dmg * charScript.damageMulti);
                charScript.applyDamage(dmgToApply, true);
            }
        else           // If magical attack
            if (Random.Range(0.0f, 1.0f) <= critRate)    // Apply crit
            {
                dmgToApply = Mathf.RoundToInt(((dmg + Mathf.RoundToInt(dmg * critDmg))) * charScript.damageMulti);
                charScript.applyCritDamage(dmgToApply, false);
            }
            else
            {
                dmgToApply = Mathf.RoundToInt((dmg - charScript.resist) * charScript.damageMulti);
                charScript.applyDamage(dmgToApply, false);
            }
            */

        

        /*
        if (dmgToApply <= 0)
            dmgToApply = 1;

        charScript.HP -= dmgToApply;
        gameObject.transform.Find("DamageText").GetComponent<Text>().text = dmgToApply.ToString();
        */
    }
}
