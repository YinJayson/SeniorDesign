using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentArmor : EquipmentItem
{
    public int defenseStat { get; set; }
    public int resistStat { get; set; }

    public EquipmentArmor(string equipName, string equipDescription, int equipID, int defenseStat, int resistStat)
    {
        this.equipName = equipName;
        this.equipDescription = equipDescription;
        this.equipID = equipID;
        this.defenseStat = defenseStat;
        this.resistStat = resistStat;
    }
    public override int getDefense()
    {
        return defenseStat;
    }
    public override int getResist()
    {
        return resistStat;
    }
}
