using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrazeSkill : MonoBehaviour, Skill
{
    public float cooldown;

    float elapsedTime;
    public bool ready;

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
        int attack = gameObject.GetComponent<CharacterScript>().attack;

        for (int i = 0; i < targetTeam.charPos.Length; i++)
        {
            if (gameObject.GetComponent<CharacterScript>().calculateCrit())
            {
                damage = attack + (attack * gameObject.GetComponent<CharacterScript>().critDamage);
                targetTeam.charPos[i].applyCritDamage(damage * 0.4f, true);
            }
            else
            {
                damage = attack;
                targetTeam.charPos[i].applyDamage(damage * 0.4f, true);
            }
        }

        DexDebuff debuff = targetTeam.charPos[0].gameObject.AddComponent<DexDebuff>();
        debuff.duration = 10.0f;
        debuff.intensity = 3;

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
}
