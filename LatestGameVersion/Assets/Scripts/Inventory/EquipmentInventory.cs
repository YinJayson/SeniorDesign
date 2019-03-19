using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentInventory : MonoBehaviour
{

    public string equipName { get; set; }
    public string equipDescription { get; set; }
    public int equipID { get; set; }
    public int hitStat { get; set; }
    public int defenceStat { get; set; }

    public EquipmentInventory(string equipName, string equipDescription, int equipID, int hitStat, int defenceStat)
    {
        this.equipName = equipName;
        this.equipDescription = equipDescription;
        this.equipID = equipID;
        this.hitStat = hitStat;
        this.defenceStat = defenceStat;
    }

}
