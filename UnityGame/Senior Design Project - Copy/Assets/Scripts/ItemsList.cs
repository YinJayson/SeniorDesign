using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsList : MonoBehaviour {

    public List<InventoryItems> item = new List<InventoryItems>();

    void listOfItems()
    {
        item = new List<InventoryItems>()
        {
            new InventoryItems("Health Potion", "Potion that raises health by 10. Can be used in and out of combat.", 1, 10, 0, 0),
            new InventoryItems("Life Potion", "Potion that is used to revive a fallen member", 2, 1000, 0,1000),
            new InventoryItems("Apple", "Healthy snack :3", 3, 5, 0, 0),
            new InventoryItems("Juice Box", "Apple juice. Nice, refreshing, made with real juice ;)", 4, 7, 0, 0),
            new InventoryItems("Grenade", "Blast your enemy away", 5, 0, 30, 0),
            new InventoryItems("Demon Scroll", "Drain some of your enemy's life away", 6, 0, 35, 0),
            new InventoryItems("Skill scroll", "Bump up your Skill EXP by 20 during battle", 7, 0, 0, 20),
        };
    }

    
}
