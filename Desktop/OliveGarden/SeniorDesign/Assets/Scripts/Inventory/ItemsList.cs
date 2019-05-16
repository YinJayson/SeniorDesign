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
            new InventoryItems("Life Potion", "Potion that is used to revive a fallen member", 1000, 0,1000,"healthpotion", 2, 20),
            new InventoryItems("Apple", "Healthy snack :3", 5, 0, 0,"apple", 3, 20),
            new InventoryItems("Sword", "Sword", 5, 0, 0,"Sword", 3, 20),
            //new InventoryItems("Juice Box", "Apple juice. Nice, refreshing, made with real juice ;)", 7, 0, 0,Resources.Load<Sprite>("Sprites/Items/healthpotion"), 4),
            //new InventoryItems("Grenade", "Blast your enemy away", 0, 30, 0,Resources.Load<Sprite>("Sprites/Items/flask"), 5),
            //new InventoryItems("Demon Scroll", "Drain some of your enemy's life away", 0, 35, 0,Resources.Load<Sprite>("Sprites/Items/book"), 6),
            //new InventoryItems("Skill scroll", "Bump up your Skill EXP by 20 during battle", 0, 0, 20,Resources.Load<Sprite>("Sprites/Items/book"), 7),
        };
    }
    public void Start() {
        /*foreach (var InventoryItems in item) {
            Debug.Log(InventoryItems.itemName + ": " + InventoryItems.itemDescription + "\nHealth Stat: " + InventoryItems.healthStat + InventoryItems.icon);
        }*/
        //GetByName("Apple");
        
        
       /* for (int i = 0; i < item.Count; i++) {
            Debug.Log(item[i].itemName);
        }
        */
        
        
        
    }

	
}