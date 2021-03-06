﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipDictionary : MonoBehaviour
{
    public Dictionary<string, EquippedItems> dictionary;

    private static bool created = false;

    void Start()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;

            dictionary = new Dictionary<string, EquippedItems>()        // Equipped items are ordered as: Helm, Armor, Legs, Weapon
            {
                { "hero1", new EquippedItems("helmetLeather", "armorCotton", "pantsCotton", "gunLaser") },
                { "hero2", new EquippedItems("helmetNothing", "armorNothing", "pantsNothing", "weaponNothing") },
                { "hero3", new EquippedItems("helmetNothing", "armorNothing", "pantsNothing", "swordIron") },
            };
        }
    }
}
