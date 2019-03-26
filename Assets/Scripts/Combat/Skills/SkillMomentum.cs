using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMomentum : MonoBehaviour, Skill
{
    string skillTag = "<b>[Momentum]</b>";
    string skillName = "Book Storm";
    string description = "Telekinetically throws a flurry of books, dealing <b>180% attack damage distributed amongst all enemies</b>";
    float cooldown = 16.0f;

    float elapsedTime = 0.0f;
    public bool ready;

    int type = 1;   // 1 = Offense, 2 = Defense, 3 = Support

    TeamScript targetTeam;
    Sprite sprite;

    /*
    void Start()
    {
        skillName = "<b>[Momentum]</b> Book Storm";
        description = "Telekinetically throws a storm of books, dealing <b>180%</b> basic attack damage distributed amongst all enemies";
        elapsedTime = 0.0f;
    }
    */

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

        int attack = Mathf.RoundToInt((float)gameObject.GetComponent<CharacterScript>().attack + gameObject.GetComponent<CharacterScript>().strength * 0.8f);

        if(targetTeam.charPos[0].alive && targetTeam.charPos[1].alive && targetTeam.charPos[2].alive)
        {
            for(int i = 0; i < 3; i++)
            {
                GameObject hit = Instantiate(Resources.Load<GameObject>("Prefabs/Attacks/AttackMomentum"), targetTeam.charPos[i].transform);
                hit.GetComponent<ApplyDamage>().dmg = Mathf.RoundToInt(attack * 0.33f);
                hit.GetComponent<ApplyDamage>().critRate = gameObject.GetComponent<CharacterScript>().critRate;
                hit.GetComponent<ApplyDamage>().critDmg = gameObject.GetComponent<CharacterScript>().critDamage;
                hit.GetComponent<ApplyDamage>().physical = gameObject.GetComponent<CharacterScript>().basicAttackType;
                hit.GetComponent<ApplyDamage>().source = gameObject.GetComponent<CharacterScript>();
            }
        }
        else if(targetTeam.charPos[0].alive && targetTeam.charPos[1].alive)
        {
            for (int i = 0; i < 2; i++)
            {
                GameObject hit = Instantiate(Resources.Load<GameObject>("Prefabs/Attacks/AttackMomentum"), targetTeam.charPos[i].transform);
                hit.GetComponent<ApplyDamage>().dmg = Mathf.RoundToInt(attack * 0.5f);
                hit.GetComponent<ApplyDamage>().critRate = gameObject.GetComponent<CharacterScript>().critRate;
                hit.GetComponent<ApplyDamage>().critDmg = gameObject.GetComponent<CharacterScript>().critDamage;
                hit.GetComponent<ApplyDamage>().physical = gameObject.GetComponent<CharacterScript>().basicAttackType;
                hit.GetComponent<ApplyDamage>().source = gameObject.GetComponent<CharacterScript>();
            }
        }
        else
        {
            GameObject hit = Instantiate(Resources.Load<GameObject>("Prefabs/Attacks/AttackMomentum"), targetTeam.charPos[0].transform);
            hit.GetComponent<ApplyDamage>().dmg = attack;
            hit.GetComponent<ApplyDamage>().critRate = gameObject.GetComponent<CharacterScript>().critRate;
            hit.GetComponent<ApplyDamage>().critDmg = gameObject.GetComponent<CharacterScript>().critDamage;
            hit.GetComponent<ApplyDamage>().physical = gameObject.GetComponent<CharacterScript>().basicAttackType;
            hit.GetComponent<ApplyDamage>().source = gameObject.GetComponent<CharacterScript>();
        }

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
