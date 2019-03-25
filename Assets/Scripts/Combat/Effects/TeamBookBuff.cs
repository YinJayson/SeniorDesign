using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamBookBuff : MonoBehaviour
{
    public float duration = 10.0f;

    public float maxDuration = 10.0f;

    TeamScript team;
    CharacterScript target;
    GameObject anim;

    void Start()
    {
        team = gameObject.GetComponent<TeamScript>();
        target = team.charPos[0];
        target.gameObject.AddComponent<BookBuff>();
        anim = Instantiate(Resources.Load<GameObject>("Prefabs/Skills/SkillBook") as GameObject, new Vector2(target.transform.position.x, target.transform.position.y), Quaternion.identity, target.transform);
    }

    void Update()
    {
        if (team.charPos[0] != target)
        {
            /* Create new buff */
            BookBuff temp = team.charPos[0].gameObject.AddComponent<BookBuff>();
            temp.duration = duration;

            /* Remove previous buff */
            target.GetComponent<BookBuff>().expire();

            /* Change target */
            target = team.charPos[0];
            anim.transform.parent = target.transform;
            anim.transform.position = target.transform.position;
        }

        duration -= Time.deltaTime;

        if (duration <= 0.0f)
            expire();
    }

    void expire()
    {
        Destroy(anim);
        Destroy(this);
    }
}
