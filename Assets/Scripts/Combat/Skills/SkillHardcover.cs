using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillHardcover : MonoBehaviour, Skill
{
    string skillTag = "<b>[Hardcover]</b>";
    string skillName = "Shield of Pages";
    string description = "Actively covers the front-most teammate with very thick books, decreasing damage by <b>20%</b> for <b>10 seconds</b>";
    float cooldown = 16.0f;

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

        targetTeam.gameObject.AddComponent<TeamBookBuff>();

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
