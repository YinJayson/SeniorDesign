using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class ItemsList : MonoBehaviour {

    public List<InventoryItems> item = new List<InventoryItems>();

    private static bool created = false;

    private void Awake()
    {
        //at the start of the game the inventory list will be called
        if(!created)
        {
            DontDestroyOnLoad(this.gameObject);

            listOfItems();

            created = true;
        }

    }

    //search for the inventory item by the item name
    public InventoryItems GetByName(string itemName) {

        for (int i = 0; i < item.Count; i++) {
            if (item[i].itemName == itemName)
            {
                return item[i];
                //Debug.Log(item[i].itemName);
            }
        }
        Debug.Log("Something went wrong in InventoryItems GetByName()");
        return null;
    }

    //method that quests calls on to add a rewarded quest item to players inentory

    public InventoryItems GetByItemID(int itemID)
    {
        for (int i = 0; i < item.Count; i++) {
            if (item[i].itemID == itemID) {
                return item[i];
            }
        }
        return null;

    }

    void listOfItems()
    {
        //list of all possible invewntory items
        item = new List<InventoryItems>()
        {
            //itemID added for quests
            new InventoryItems("Health Potion", "Potion that raises health by 10. Can be used in and out of combat.", 10, 0, 0, "healthpotion", 1, 20),
            new InventoryItems("Life Potion", "Potion that is used to revive a fallen member", 1000, 0,1000,"healthpotion", 2, 1000),
            new InventoryItems("Apple", "Healthy snack :3", 5, 0, 0,"apple", 3, 5),
            new InventoryItems("Sword", "A simple iron sword", 0, 50, 0, "Sword", 4, 200),
            new InventoryItems("Dark Sword", "A black magical sword", 0, 100, 50, "swordGradient", 5, 400),
            new InventoryItems("Mana Potion", "Potion that raises the drinker's soul energy.", 0, 0, 10, "manapotion", 6, 20),
            new InventoryItems("Bomb", "Messy and loud, use with caution", 0, 500, 0, "bomb", 7, 300)
        };
    }
}
