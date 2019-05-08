using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentItem : Item
{
    public int slot;
    public EquipmentItem()
    {
        id = "";
        name = "";
        description = "";
        value = 0;
        slot = 0;
        stacks = false;
        count = 0;
        sprite = null;
    }
    public EquipmentItem(string id, string name, string description, int value, int slot)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.value = value;
        this.slot = slot;
        this.stacks = false;
        this.count = 1;
        this.sprite = Resources.Load<Sprite>("Sprites/Items/" + name) as Sprite;
    }
}
