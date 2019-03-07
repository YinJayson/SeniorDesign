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

    CharacterScript charScript;

    public void damage()
    {
        charScript = gameObject.transform.parent.GetComponent<CharacterScript>();
        Debug.Log("critRate: " + critRate);
        if (physical)    // If physical attack
            if (Random.Range(0.0f, 1.0f) <= critRate)    // Apply crit
            {
                dmgToApply = Mathf.RoundToInt(((dmg + (int)(dmg * critDmg)) - charScript.defense) * charScript.damageMulti);
                gameObject.transform.Find("DamageText").GetComponent<Text>().fontSize = 18;
            }
            else
                dmgToApply = Mathf.RoundToInt((dmg - charScript.defense) * charScript.damageMulti);
        else           // If magical attack
            if (Random.Range(0.0f, 1.0f) <= critRate)    // Apply crit
            {
                dmgToApply = Mathf.RoundToInt(((dmg + (int)(dmg * critDmg)) - charScript.resist) * charScript.damageMulti);
                gameObject.transform.Find("DamageText").GetComponent<Text>().fontSize = 18;
            }
        else
            dmgToApply = Mathf.RoundToInt((dmg - charScript.resist) * charScript.damageMulti);

        if (dmgToApply <= 0)
            dmgToApply = 1;

        charScript.HP -= dmgToApply;
        gameObject.transform.Find("DamageText").GetComponent<Text>().text = dmgToApply.ToString();
    }
}
