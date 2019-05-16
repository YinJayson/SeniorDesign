using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCorrosion : MonoBehaviour, Skill
{
    string skillTag = "<b>[Corrosion]</b>";
    string skillName = "Vial of Rust";
    string description = "Throws a vial, dealing <b>3x30% attack damage</b> and splashing the target with a volatile rusting reagent, <b>reducing armor and resistance by 50%</b> for <b>8 seconds</b>";
    float cooldown = 14.0f;

    float elapsedTime = 0.0f;
    public bool ready;

    int type = 1;   // 1 = Offense, 2 = Defense, 3 = Support

    TeamScript targetTeam;
    Sprite sprite;

    void Update()
    {
        if (elapsedTime > 0.0f)
        {
            elapsedTime -= Time.deltaTime;

            if (elapsedTime <= 0.0f)
                elapsedTime = 0.0f;
        }

        if (elapsedTime <= 0.0f)
            ready = true;
        else
            ready = false;
    }

    public void skill()
    {
        targetTeam = gameObject.transform.GetComponentInParent<TeamScript>().enemyTeam;

        int attack = Mathf.RoundToInt(gameObject.GetComponent<CharacterScript>().attack * 0.9f);

        GameObject hit = Instantiate(Resources.Load<GameObject>("Prefabs/Attacks/AttackCorrosion"), targetTeam.charPos[0].transform);
        hit.GetComponent<ApplyDamage>().dmg = attack;
        hit.GetComponent<ApplyDamage>().critRate = gameObject.GetComponent<CharacterScript>().critRate;
        hit.GetComponent<ApplyDamage>().critDmg = gameObject.GetComponent<CharacterScript>().critDamage;
        hit.GetComponent<ApplyDamage>().physical = gameObject.GetComponent<CharacterScript>().basicAttackType;
        hit.GetComponent<ApplyDamage>().source = gameObject.GetComponent<CharacterScript>();

        elapsedTime = cooldown;
        skillCooldown();
    }

    public void skillCooldown()
    {
        Instantiate(Resources.Load<GameObject>("Prefabs/SkillCooldownIcon") as GameObject, gameObject.transform.localPosition, Quaternion.identity, gameObject.transform);
    }

    public bool getReady()
    {
        return ready;
    }
    public int getType()
    {
        return type;
    }
    public float getCooldown()
    {
        return cooldown;
    }
    public float getElapsed()
    {
        return elapsedTime;
    }
    public string getTag()
    {
        return skillTag;
    }
    public string getName()
    {
        return skillName;
    }
    public string getDescription()
    {
        return description;
    }
}
