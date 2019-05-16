using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillChanger : MonoBehaviour
{
    string id;
    public int skill;

    Button button;

    void Start ()
    {
        id = gameObject.transform.parent.GetComponent<SkillHighlighter>().id;
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        GameObject.FindObjectOfType<SkillDictionary>().setSkill(id, skill);
        Destroy(gameObject.transform.parent.gameObject);
    }
}
