using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentDictionary : MonoBehaviour
{

    public Dictionary<string, EquipmentArmor> armorDictionary;
    public Dictionary<string, EquipmentWeapon> weaponDictionary;

    private static bool created = false;

    private void Awake()
    {
        //at the start of the game the inventory list will be called
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);

            armorDictionary = new Dictionary<string, EquipmentArmor>()
            {
                { "helmetNothing", new EquipmentArmor("helmetNothing", "Nothing", "Nothing but your hair flowing in the breeze.", 0, 0, 0, 1) },
                { "armorNothing", new EquipmentArmor("armorNothing", "Nothing", "Nothing but pure strength to block damage.", 0, 0, 0, 2) },
                { "pantsNothing", new EquipmentArmor("pantsNothing", "Nothing", "Nothing but ", 0, 0, 0, 3) },
                { "armorCotton", new EquipmentArmor("armorCotton", "Cotton Tunic", "Peasant clothes, but better than nothing.", 10, 2, 2, 2) },
                { "pantsCotton", new EquipmentArmor("pantsCotton", "Cotton Pants", "Lightweight <i>and</i> fashionable.", 10, 1, 2, 3) },
                { "armorLeather", new EquipmentArmor("armorLeather", "Leather Armor", "Hard and sturdy.", 50, 5, 2, 2) },
                { "helmetLeather", new EquipmentArmor("helmetLeather", "Leather Helmet", "Acts as a second skull.", 30, 7, 5, 1) }
            };

            weaponDictionary = new Dictionary<string, EquipmentWeapon>()
            {
                { "weaponNothing", new EquipmentWeapon("Nothing", "Nothing but the default", 0, 0, true) },
                { "swordIron", new EquipmentWeapon("Iron Sword", "A sturdy sword. Good for physical attacks.", 30, 8, true) },
                { "wandWind", new EquipmentWeapon("Wand of Wind", "Wand imbued with air magic. Good for magical attacks", 35, 9, false) },
                { "gunLaser", new EquipmentWeapon("Laser Gun", "Fururistic gun. Not too sure which time period we're in...", 1500, 43, false) }
            };

            created = true;
        }

    }

    //search the equipment database by equipment name
    /*
    public Item GetByName(string equipName)
    {
        for (int i = 0; i < item.Count; i++)
        {
            if (item[i].name == equipName)
            {
                return item[i];
            }
        }
        return null;
    }
    */

}
