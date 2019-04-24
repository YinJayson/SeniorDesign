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
                { "armorCotton", new EquipmentArmor("Cotton Tunic", "Peasant clothes. Itchy as hell. Came with the character. Not stylish but whatever he's poor.", 10, 2, 2) },
                { "pantsCotton", new EquipmentArmor("Cotton Pants", "Cotton pants to match that nasty cotton tunic.", 10, 1, 2) },
                { "armorLeather", new EquipmentArmor("Leather Armor", "Isn't the best choice in protection but....it issss edible...", 50, 5, 2) },
                { "helmetLeather", new EquipmentArmor("Leather Helmet", "Fashionable as hell", 30, 7, 5) }
            };

            weaponDictionary = new Dictionary<string, EquipmentWeapon>()
            {
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
