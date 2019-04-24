using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipDictionary : MonoBehaviour
{
    public Dictionary<string, EquippedItems> dictionary;

    private static bool created = false;

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;

            dictionary = new Dictionary<string, EquippedItems>()        // Equipped items are ordered as: Helm, Armor, Legs, Weapon
            {
                { "hero1", new EquippedItems("Leather Helmet", "Leather Armor", "Cotton Pants", "Laser Gun") }
            };
        }
    }
}
