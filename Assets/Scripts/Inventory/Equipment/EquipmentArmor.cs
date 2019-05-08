using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentArmor : EquipmentItem
{
    public int defenseStat;
    public int resistStat;

    public EquipmentArmor(string id, string name, string description, int value, int defenseStat, int resistStat, int slot)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.sprite = Resources.Load<Sprite>("Sprites/Items/" + id) as Sprite;
        this.defenseStat = defenseStat;
        this.resistStat = resistStat;
        this.slot = slot;

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
