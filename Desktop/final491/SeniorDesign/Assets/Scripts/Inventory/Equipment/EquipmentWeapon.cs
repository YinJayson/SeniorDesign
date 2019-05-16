using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentWeapon : EquipmentItem
{
    public int attack;
    public bool atkType;

    public EquipmentWeapon(string name, string description, int value, int attack, bool atkType)
    {
        this.name = name;
        this.description = description;
        this.value = value;
        this.attack = attack;
        this.atkType = atkType;

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
