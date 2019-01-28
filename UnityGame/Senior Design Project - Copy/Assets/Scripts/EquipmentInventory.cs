using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentInventory : MonoBehaviour
{

    string equipName { get; set; }
    string equipDescription { get; set; }
    int equipID { get; set; }
    int hitStat { get; set; }
    int defenceStat { get; set; }

    public EquipmentInventory(string equipName, string equipDescription, int equipID, int hitStat, int defenceStat)
    {
        this.equipName = equipName;
        this.equipDescription = equipDescription;
        this.equipID = equipID;
        this.hitStat = hitStat;
        this.defenceStat = defenceStat;
    }

}
