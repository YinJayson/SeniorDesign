using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentWeapon : EquipmentItem
{
    public int attack;
    public bool atkType;

    public EquipmentWeapon(string id, string name, string description, int value, int attack, bool atkType)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.value = value;
        this.sprite = Resources.Load<Sprite>("Sprites/Items/" + id) as Sprite;
        this.attack = attack;
        this.atkType = atkType;
        this.slot = 4;

        this.stacks = false;    // Weapons do not stack
    }
    public int getAttack()
    {
        return attack;
    }
    public bool getAtkType()
    {
        return atkType;
    }
}
