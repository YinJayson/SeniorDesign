using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDefense : MonoBehaviour, Skill
{
    string skillTag = "<b>[Defense]</b>";
    string skillName = "Skeptical Approach";
    string description = "Heightens the senses, <b>decreasing incoming damage</b> by <b>15%</b> for <b>6 seconds</b> for <b>all allies</b>";
    float cooldown = 12.0f;

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
        targetTeam = gameObject.transform.GetComponentInParent<TeamScript>();

        for(int i = 0; i < targetTeam.charPos.Length; i++)
        {
            DecreaseDamageBuff buff = targetTeam.charPos[i].gameObject.AddComponent<DecreaseDamageBuff>();
            buff.duration = 6.0f;
            buff.intensity = 0.2f;
        }

        elapsedTime = cooldown;
        skillCooldown();
    }

    public void skillCooldown()
    {
        Instantiate(Resources.Load<GameObject>("Prefabs/SkillCooldownIcon") as GameObject, new Vector2(0, 0), Quaternion.identity, targetTeam.charPos[0].gameObject.transform);
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
