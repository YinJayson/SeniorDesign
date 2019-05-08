using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentArmor : Item
{
    public int defenseStat;
    public int resistStat;

    public EquipmentArmor(string name, string description, int value, int defenseStat, int resistStat)
    {
        this.name = name;
        this.description = description;
        this.value = value;
        this.defenseStat = defenseStat;
        this.resistStat = resistStat;

        this.stacks = false;    // Armors do not stack
    }
    public int getDefense()
    {
        return defenseStat;
    }
    public int getResist()
    {
        return resistStat;
    }
}
