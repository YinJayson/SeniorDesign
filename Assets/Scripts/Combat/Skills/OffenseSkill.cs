using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffenseSkill : MonoBehaviour, Skill
{
    string skillName;
    string description;
    float cooldown = 8.0f;

    float elapsedTime;
    public bool ready;

    int type = 1;   // 1 = Offense, 2 = Defense, 3 = Support

    TeamScript targetTeam;
    Sprite sprite;

    void Start()
    {
        skillName = "<b>[Offense]</b> Unsheath";
        description = "Forcefully unsheathes the sword, accidentally launching it. The impact deals <b>160%</b> basic attack damage";
        elapsedTime = 0.0f;
    }

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

        int attack = Mathf.RoundToInt((float) gameObject.GetComponent<CharacterScript>().attack + gameObject.GetComponent<CharacterScript>().strength * 0.6f);

        GameObject hit = Instantiate(Resources.Load<GameObject>("Prefabs/OffenseAttack"), targetTeam.charPos[0].transform);
        hit.GetComponent<ApplyDamage>().dmg = attack;
        hit.GetComponent<ApplyDamage>().critRate = gameObject.GetComponent<CharacterScript>().critRate;
        hit.GetComponent<ApplyDamage>().critDmg = gameObject.GetComponent<CharacterScript>().critDamage;
        hit.GetComponent<ApplyDamage>().physical = gameObject.GetComponent<CharacterScript>().basicAttackType;

        elapsedTime = cooldown;
        skillCooldown();
    }

    public void skillCooldown()
    {
        GameObject icon = Instantiate(Resources.Load<GameObject>("Icons/SkillCooldownIcon") as GameObject, gameObject.transform.localPosition, Quaternion.identity, gameObject.transform);
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
    public string getName()
    {
        return skillName;
    }
    public string getDescription()
    {
        return description;
    }
}
