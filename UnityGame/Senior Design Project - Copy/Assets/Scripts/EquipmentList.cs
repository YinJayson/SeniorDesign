using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentList : MonoBehaviour {

    public List<EquipmentInventory> item = new List<EquipmentInventory>();

    void listOfItems()
    {
        item = new List<EquipmentInventory>()
        {
            new EquipmentInventory("Stick", "Pitiful weapon that the main character starts off with", 1, 3, 0),
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
        };
    }

    /*
     * // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}*/
}
