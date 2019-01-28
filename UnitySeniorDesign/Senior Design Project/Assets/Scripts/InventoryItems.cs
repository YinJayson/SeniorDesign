using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryItems : MonoBehaviour {
    //item attributes
    public string itemName;
    public string itemDescription;
    public int itemID;
    public int healthStat;
    public int skillStat;
    public int attackStat;
    public Sprite icon;

    public InventoryItems(string itemName, string itemDescription, int itemID, int healthStat, int attackStat, int skillStat, Sprite icon)
    {
        this.itemName = itemName;
        this.itemDescription = itemDescription;
        this.itemID = itemID;
        this.healthStat = healthStat;
        this.attackStat = attackStat;
        this.skillStat = skillStat;
        this.icon = Resources.Load<Sprite>("Art/Items/" + itemName);
    }
   
 
}
