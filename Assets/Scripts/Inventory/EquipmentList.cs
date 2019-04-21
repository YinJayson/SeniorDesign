using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentList : MonoBehaviour
{

    public List<EquipmentInventory> item = new List<EquipmentInventory>();

    private void Awake()
    {
        //at the start of the game the inventory list will be called
        listOfEquipment();
    }

    void listOfEquipment()
    {
        item = new List<EquipmentInventory>()
        {
            new EquipmentWeapon("Stick", "Pitiful weapon that the main character starts off with", 1, 3, true),
            new EquipmentWeapon("Knife", "Basic knife found in an kitchen. Would not reccommend going into combat with it but whatever", 2, 4, true),
            new EquipmentWeapon("Crossbow", "Simple crossbow that comes with [insert characters name when we come up with one]", 3, 4, true),
            new EquipmentArmor("Cotton Tunic", "Peasant clothes. Itchy as hell. Came with the character. Not stylish but whatever he's poor.", 4, 2, 2),
            new EquipmentArmor("Cotton Pants", "Cotton pants to match that nasty cotton tunic.", 5, 1, 2),
            new EquipmentArmor("Peasant Shoes", "Main characters father made them from scratch. They suck.", 6, 1, 2),
            new EquipmentWeapon("Demon Sword", "Rare sword rumored to have been forged in the underworld", 7, 55, true),
            new EquipmentWeapon("Elven Bow", "Wooden bow fored by elves", 8, 30, true),
            new EquipmentArmor("Leather Armor", "Isn't the best choice in protection but....it issss edible...", 9, 5, 20),
            new EquipmentArmor("Wooden Shield", "Again main character was poor and couldn't afford much", 10, 4, 5),
            new EquipmentArmor("Leather Helmet", "Fashionable as hell", 11, 3, 13),
            new EquipmentArmor("Iron Shield", "Its a shield...made out of iron...", 12, 7, 30),
            new EquipmentArmor("Mage Robe", "The mage came with it", 13, 1, 5),
            new EquipmentArmor("Demon Robe", "Robe made by demon essence? Idk man.", 14, 1, 45),
            new EquipmentWeapon("Laser Gun", "Fururistic gun. Not too sure which time period we're in...", 15, 43, false),
            new EquipmentArmor("Steel Toed Boots", "boots ... with steel in them...", 16, 0, 32),

            /*
             *             new EquipmentInventory("Stick", "Pitiful weapon that the main character starts off with", 1, 3, 0),
            new EquipmentInventory("Knife", "Basic knife found in an kitchen. Would not reccommend going into combat with it but whatever", 2, 4, 0),
            new EquipmentInventory("Crossbow", "Simple crossbow that comes with [insert characters name when we come up with one]", 3, 4, 0),
            new EquipmentInventory("Cotton Tunic", "Peasant clothes. Itchy as hell. Came with the character. Not stylish but whatever he's poor.", 4, 0, 2),
            new EquipmentInventory("Cotton Pants", "Cotton pants to match that nasty cotton tunic.", 5, 0, 2),
            new EquipmentInventory("Peasant Shoes", "Main characters father made them from scratch. They suck.", 6, 0, 2),
            new EquipmentInventory("Demon Sword", "Rare sword rumored to have been forged in the underworld", 7, 55, 0),
            new EquipmentInventory("Elven Bow", "Wooden bow fored by elves", 8, 30, 0),
            new EquipmentInventory("Leather Armor", "Isn't the best choice in protection but....it issss edible...", 9, 0, 20),
            new EquipmentInventory("Wooden Shield", "Again main character was poor and couldn't afford much", 10, 0, 5),
            new EquipmentInventory("Leather Helmet", "Fashionable as hell", 11, 0, 13),
            new EquipmentInventory("Iron Shield", "Its a shield...made out of iron...", 12, 0, 30),
            new EquipmentInventory("Mage Robe", "The mage came with it", 13, 0, 5),
            new EquipmentInventory("Demon Robe", "Robe made by demon essence? Idk man.", 14, 0, 45),
            new EquipmentInventory("Laser Gun", "Fururistic gun. Not too sure which time period we're in...", 15, 43, 0),
            new EquipmentInventory("Steel Toed Boots", "boots ... with steel in them...", 16, 0, 32),
            */
        };
    }

    //search the equipment database by equipment name
    public EquipmentInventory GetByName(string equipName)
    {
        for (int i = 0; i < item.Count; i++)
        {
            if (item[i].equipName == equipName)
            {
                return item[i];
            }
        }
        return null;
    }

}
