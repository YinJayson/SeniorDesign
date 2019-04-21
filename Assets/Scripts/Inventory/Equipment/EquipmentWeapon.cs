using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentWeapon : EquipmentInventory
{
    public int atkStat { get; set; }
    public bool atkType { get; set; }   // True = Physical, False = Magical

    public EquipmentWeapon(string equipName, string equipDescription, int equipID, int atkStat, bool atkType)
    {
        this.equipName = equipName;
        this.equipDescription = equipDescription;
        this.equipID = equipID;
        this.atkStat = atkStat;
        this.atkType = atkType;
    }

    public override int getAtk()
    {
        return atkStat;
    }
    public override bool getAtkType()
    {
        return atkType;
    }
}
