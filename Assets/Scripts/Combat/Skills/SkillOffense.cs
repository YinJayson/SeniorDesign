using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillOffense : MonoBehaviour, Skill
{
    string skillTag = "<b>[Offense]</b>";
    string skillName = "Unsheath";
    string description = "Forcefully unsheathes the sword, accidentally launching it. The impact deals <b>160%</b> attack damage and has +20% critical chance";
    float cooldown = 8.0f;

    float elapsedTime = 0.0f;
    public bool ready;

    int type = 1;   // 1 = Offense, 2 = Defense, 3 = Support

    TeamScript targetTeam;
    Sprite sprite;

    /*
    void Start()
    {
        string skillName = "<b>[Offense]</b> Unsheath";
        string description = "Forcefully unsheathes the sword, accidentally launching it. The impact deals <b>160%</b> attack damage and has +20% critical chance";
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

        int attack = Mathf.RoundToInt((float) gameObject.GetComponent<CharacterScript>().attack + gameObject.GetComponent<CharacterScript>().strength * 0.6f);

        GameObject hit = Instantiate(Resources.Load<GameObject>("Prefabs/Attacks/AttackOffense"), targetTeam.charPos[0].transform);
        hit.GetComponent<ApplyDamage>().dmg = attack;
        hit.GetComponent<ApplyDamage>().critRate = gameObject.GetComponent<CharacterScript>().critRate + 0.20f;
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
