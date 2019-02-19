using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryItems : MonoBehaviour {
    //item attributes
    public string itemName { get; set; }
    public string itemDescription { get; set; }
    public int healthStat { get; set; }
    public int skillStat { get; set; }
    public int attackStat { get; set; }
    public Sprite sprite { get; set; }

    public InventoryItems(string itemName, string itemDescription, int healthStat, int attackStat, int skillStat, Sprite icon)
    {
        this.itemName = itemName;
        this.itemDescription = itemDescription;
        this.healthStat = healthStat;
        this.attackStat = attackStat;
        this.skillStat = skillStat;
        this.sprite = Resources.Load<Sprite>("Art/Items/" + itemName);
    }

    // testing to be sent to shop
//    public InventoryItems sword = new InventoryItems("Grenade", "Blast your enemy away", 0, 30, 0, Resources.Load<Sprite>("Art/Items/Health Potion"));

}
