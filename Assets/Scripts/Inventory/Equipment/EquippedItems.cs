using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedItems
{
    // Helmet, armor, shoes, weapon
    public string helm;
    public string armor;
    public string pants;
    public string weapon;

    public EquippedItems(string helmID, string armorID, string pantsID, string weaponID)
    {
        helm = helmID;
        armor = armorID;
        pants = pantsID;
        weapon = weaponID;
    }
}
