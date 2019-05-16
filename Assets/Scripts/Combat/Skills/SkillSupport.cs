using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSupport : MonoBehaviour, Skill
{
    string skillTag = "<b>[Support]</b>";
    string skillName = "Run!";
    string description = "Yells at everyone to move faster, <b>increasing Dexterity</b> by <b>20%</b> for <b>8 seconds</b>";
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
        targetTeam = gameObject.transform.GetComponentInParent<TeamScript>();

        for (int i = 0; i < targetTeam.charPos.Length; i++)
        {
            DexBuff buff = targetTeam.charPos[i].gameObject.AddComponent<DexBuff>();
            buff.duration = 8.0f;
            buff.intensity = 0.2f;
        }

        elapsedTime = cooldown;
        skillCooldown();
    }

    public void skillCooldown()
    {
        Instantiate(Resources.Load<GameObject>("Prefabs/SkillCooldownIcon") as GameObject, new Vector2(0, 0), Quaternion.identity, gameObject.transform);
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
