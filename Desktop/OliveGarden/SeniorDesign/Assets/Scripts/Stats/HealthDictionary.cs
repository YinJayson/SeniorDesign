﻿using System.Collections;
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

            dictionary = new Dictionary<string, int>()
            {
                { "hero1", Mathf.RoundToInt(GameObject.FindObjectOfType<CharacterDictionary>().getStats("hero1").strength * 3.75f) },
                { "hero2", Mathf.RoundToInt(GameObject.FindObjectOfType<CharacterDictionary>().getStats("hero2").strength * 3.75f) },
                { "hero3", Mathf.RoundToInt(GameObject.FindObjectOfType<CharacterDictionary>().getStats("hero3").strength * 3.75f) }
            };

            created = true;
        }
    }

    public int getHealth(string id)
    {
        return dictionary[id];
    }
}
