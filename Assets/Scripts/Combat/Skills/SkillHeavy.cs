using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillHeavy : MonoBehaviour, Skill
{
    string skillTag = "<b>[Heavy]</b>";
    string skillName = "Coma-tome";
    string description = "Flings a very heavy book at the enemy's head, inflicting <b>Stun</b> for <b>3 seconds</b> and dealing <b>20% attack damage</b>";
    float cooldown = 16.0f;

    float elapsedTime = 0.0f;
    public bool ready;

    int type = 3;   // 1 = Offense, 2 = Defense, 3 = Support

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

        int attack = Mathf.RoundToInt((float) gameObject.GetComponent<CharacterScript>().attack * 0.2f);

        GameObject hit = Instantiate(Resources.Load<GameObject>("Prefabs/Attacks/AttackHeavy"), targetTeam.charPos[0].transform);
        hit.GetComponent<ApplyDamage>().dmg = attack;
        hit.GetComponent<ApplyDamage>().critRate = gameObject.GetComponent<CharacterScript>().critRate;
        hit.GetComponent<ApplyDamage>().critDmg = gameObject.GetComponent<CharacterScript>().critDamage;
        hit.GetComponent<ApplyDamage>().physical = gameObject.GetComponent<CharacterScript>().basicAttackType;
        hit.GetComponent<ApplyDamage>().source = gameObject.GetComponent<CharacterScript>();
        hit.GetComponent<ApplyDamage>().duration = 3.0f;

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
