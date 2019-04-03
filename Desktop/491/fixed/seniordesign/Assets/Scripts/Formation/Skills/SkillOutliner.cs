using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillHighlighter : MonoBehaviour
{
    public string id;

	void Start ()
    {
        int skillToHighlight = GameObject.FindObjectOfType<SkillDictionary>().getSkill(id);

        Transform target = gameObject.transform.Find("SkillSlot" + skillToHighlight);

        Instantiate(Resources.Load<GameObject>("Prefabs/SkillHighlight"), target.transform);
	}
}
