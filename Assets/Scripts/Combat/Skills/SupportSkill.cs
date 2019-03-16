using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportSkill : MonoBehaviour, Skill
{
    string skillName;
    string description;

    float cooldown = 12.0f;

    float elapsedTime;
    public bool ready;

    int type = 3;   // 1 = Offense, 2 = Defense, 3 = Support

    TeamScript targetTeam;
    Sprite sprite;

    void Start()
    {
        skillName = "<b>[Support]</b> Run!";
        description = "Yells at everyone to move faster, increasing Dexterity by <b>3</b> for <b>10 seconds</b>";
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
        targetTeam = gameObject.transform.GetComponentInParent<TeamScript>();

        for (int i = 0; i < targetTeam.charPos.Length; i++)
        {
            DexBuff buff = targetTeam.charPos[i].gameObject.AddComponent<DexBuff>();
            buff.duration = 10.0f;
            buff.intensity = 3;
        }

        elapsedTime = cooldown;
        skillCooldown();
    }

    public void skillCooldown()
    {
        GameObject icon = Instantiate(Resources.Load<GameObject>("Icons/SkillCooldownIcon") as GameObject, new Vector2(0, 0), Quaternion.identity, gameObject.transform);
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
