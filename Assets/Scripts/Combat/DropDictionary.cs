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

            dictionary = new Dictionary<string, DropChance>()
            {
                { "slime", new DropChance(5, "Apple", 50) },
                { "orc", new DropChance(50, "Health Potion", 20, "Apple", 40) },
                { "skeleton", new DropChance(50, "Health Potion", 20) },
                { "livingArmor", new DropChance() },
                { "goblin", new DropChance(50, "Health Potion", 25, "Apple", 100) },
                { "generic", new DropChance() },
            };
        }
    }
}
