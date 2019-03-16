using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffenseSkill : MonoBehaviour, Skill
{
    float cooldown = 8.0f;

    float elapsedTime;
    public bool ready;

    int type = 1;   // 1 = Offense, 2 = Defense, 3 = Support

    TeamScript targetTeam;
    Sprite sprite;

    void Start()
    {
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

        float damage = 0;
        float attack = gameObject.GetComponent<CharacterScript>().attack + gameObject.GetComponent<CharacterScript>().strength * 0.6f;

        if (gameObject.GetComponent<CharacterScript>().calculateCrit())
        {
            damage = attack + (attack * gameObject.GetComponent<CharacterScript>().critDamage);
            targetTeam.charPos[0].applyCritDamage(damage, true);
        }
        else
        {
            damage = attack;
            targetTeam.charPos[0].applyDamage(damage, true);
        }

        elapsedTime = cooldown;
        skillCooldown();
    }

    public void skillCooldown()
    {
        GameObject icon = Instantiate(Resources.Load<GameObject>("Icons/SkillCooldownIcon") as GameObject, new Vector2(0, 0), Quaternion.identity, targetTeam.charPos[0].gameObject.transform);
        icon.GetComponent<SkillCooldownIcon>().cooldown = cooldown;
        icon.GetComponent<SkillCooldownIcon>().target = gameObject.GetComponent<CharacterScript>();
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
}
