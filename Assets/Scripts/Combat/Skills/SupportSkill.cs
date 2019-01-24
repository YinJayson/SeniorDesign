using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportSkill : MonoBehaviour, Skill
{
    float cooldown = 12.0f;

    float elapsedTime;
    public bool ready;

    int type = 3;   // 1 = Offense, 2 = Defense, 3 = Support

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
