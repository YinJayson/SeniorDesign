using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropDictionary : MonoBehaviour
{
    public Dictionary<string, DropChance> dictionary;

    private static bool created = false;

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;

            dictionary = new Dictionary<string, DropChance>();

            DropChance dropSlime = new DropChance(50, "Apple", 50, "", 0, "", 0, "", 0);

            dictionary.Add("slime", dropSlime);
        }
    }
}
