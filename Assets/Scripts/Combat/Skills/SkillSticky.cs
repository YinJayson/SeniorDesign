using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSticky : MonoBehaviour, Skill
{
    string skillTag = "<b>[Sticky]</b>";
    string skillName = "Flask of Viscosity";
    string description = "Throws a flask, dealing <b>20% attack damage</b> and splashing the target with a viscous substance, <b>reducing dexterity of the target by 50%</b> for <b>6 seconds</b>";
    float cooldown = 14.0f;

    float elapsedTime = 0.0f;
    public bool ready;

    int type = 2;   // 1 = Offense, 2 = Defense, 3 = Support

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

        int attack = Mathf.RoundToInt(gameObject.GetComponent<CharacterScript>().attack * 0.2f);

        GameObject hit = Instantiate(Resources.Load<GameObject>("Prefabs/Attacks/AttackSticky"), targetTeam.charPos[0].transform);
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
        Instantiate(Resources.Load<GameObject>("Icons/SkillCooldownIcon") as GameObject, gameObject.transform.localPosition, Quaternion.identity, gameObject.transform);
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
