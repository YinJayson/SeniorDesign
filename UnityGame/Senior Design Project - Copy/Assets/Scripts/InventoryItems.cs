using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryItems : MonoBehaviour {
    string ItemName;
    string ItemDescription;
    int ItemID;
    int HealthStat;
    int AttackStat;
    int SkillStat;

    public InventoryItems(string itemName, string itemDescription, int itemID, int healthStat, int attackStat, int skillStat)
    {
        this.ItemName = itemName;
        this.ItemDescription = itemDescription;
        this.ItemID = itemID;
        this.HealthStat = healthStat;
        this.AttackStat = attackStat;
        this.SkillStat = skillStat;
    }
   
 
}
