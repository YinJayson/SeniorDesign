using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDictionary : MonoBehaviour
{
    public Dictionary<string, int> dictionary;

    private static bool created = false;

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);

            dictionary = new Dictionary<string, int>();
            dictionary.Add("hero1", 1);
            dictionary.Add("hero2", 2);
            dictionary.Add("hero3", 3);

            created = true;
        }
    }
    public void setSkill(string id, int skill)
    {
        dictionary[id] = skill;
        Debug.Log("hero1 - Skill " + dictionary["hero1"]);
        Debug.Log("hero2 - Skill " + dictionary["hero2"]);
        Debug.Log("hero3 - Skill " + dictionary["hero3"]);
    }

    public int getSkill(string id)
    {
        return dictionary[id];
    }
}
