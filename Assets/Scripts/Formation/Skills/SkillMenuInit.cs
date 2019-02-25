using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMenuInit : MonoBehaviour
{
    string id;

    void Update()
    {
        id = gameObject.transform.parent.parent.GetComponent<FormCard>().id;
    }
    public void initMenu()
    {
        Instantiate(Resources.Load("Menus/SkillMenu" + id), gameObject.transform.parent.parent.parent);
    }
}
