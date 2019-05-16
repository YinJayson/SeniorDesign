using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillRegeneration : MonoBehaviour, Skill
{
    string skillTag = "<b>[Regeneration]</b>";
    string skillName = "Healing Bottle";
    string description = "Reveals a hidden Bottle of Healing, <b>healing the whole party by 10% of their Max HP</b>";
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
            if (targetTeam.charPos[i].alive)
                targetTeam.charPos[i].applyHeal(Mathf.RoundToInt(targetTeam.charPos[i].maxHP * 0.1f));

        elapsedTime = cooldown;
        skillCooldown();
    }

    public void skillCooldown()
    {
        Instantiate(Resources.Load<GameObject>("Prefabs/SkillCooldownIcon") as GameObject, gameObject.transform.localPosition, Quaternion.identity, gameObject.transform);
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
