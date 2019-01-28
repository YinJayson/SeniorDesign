using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDictionary : MonoBehaviour
{
    public Dictionary<string, int> dictionary;

    private static bool created = false;

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;

            dictionary = new Dictionary<string, int>();

            dictionary.Add("adrian", -1);
            dictionary.Add("lua", -1);
            dictionary.Add("avis", -1);
        }
    }

    public int getHealth(string id)
    {
        return dictionary[id];
    }
}
