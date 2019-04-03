using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryItems {
    //item attributes
    public string itemName { get; set; }
    public string itemDescription { get; set; }
    public int healthStat { get; set; }
    public int skillStat { get; set; }
    public int attackStat { get; set; }
    public Sprite sprite { get; set; }
    //item id added for use with quests
    public int itemID { get; set; }

    public InventoryItems(string itemName, string itemDescription, int healthStat, int attackStat, int skillStat, Sprite icon, int itemID)
    {
        this.itemName = itemName;
        this.itemDescription = itemDescription;
        this.healthStat = healthStat;
        this.attackStat = attackStat;
        this.skillStat = skillStat;
        this.sprite = Resources.Load<Sprite>("Art/Items/" + itemName);
        this.itemID = itemID;
    }
   
 
}
