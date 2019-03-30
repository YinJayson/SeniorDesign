using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDictionary : MonoBehaviour
{
    public Dictionary<string, CharacterStats> dictionary;

    private static bool created = false;

    void Awake()
    {
        if(!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;

            dictionary = new Dictionary<string, CharacterStats>()
            {
                { "hero1", new CharacterStats("hero", 6, 4, 2, true, 0, 0, 0) },
                { "hero2", new CharacterStats("ranger", 3, 6, 3, true, 0, 0, 0) },
                { "hero3", new CharacterStats("alchemist", 1, 4, 7, false, 0, 0, 0) },

                { "generic", new CharacterStats("Slime", 3, 3, 3, true, 5, 5) },

                { "slime", new CharacterStats("Slime", 1, 6, 1, true, 5, 5) },
                { "orc", new CharacterStats("Orc", 5, 2, 2, true, 7, 5) },
                { "skeleton", new CharacterStats("Skeleton", 2, 5, 5, false, 6, 5) },
                { "livingArmor", new CharacterStats("LivingArmor", 8, 2, 0, true, 8, 5) },
                { "goblin", new CharacterStats("Goblin", 5, 5, 2, true, 5, 5) }
            };
        }
    }

    public CharacterStats getStats(string id)
    {
        return dictionary[id];
    }
}
