using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class shopDatabase : MonoBehaviour
{
    public List<InventoryItems> item = new List<InventoryItems>();
    void Awake()
    {
        listOfItems();
    }
    //search for the inventory item by the item name
    public InventoryItems GetByName(string itemName)
    {
        for (int i = 0; i < item.Count; i++)
        {
            if (item[i].itemName == itemName)
            {
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
            new InventoryItems("Health Potion", "Potion that raises health by 10. Can be used in and out of combat.", 10, 0, 0, Resources.Load<Sprite>("Art/Items/Health Potion"), 1),
            new InventoryItems("Grenade", "Blast your enemy away", 0, 30, 0,Resources.Load<Sprite>("Art/Items/Health Potion"), 2),
            new InventoryItems("Sword", "simple sword", 0, 0, 20,Resources.Load<Sprite>("Art/Items/Sword"), 3),
        };
    }
 

}
