using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedItems
{
    // Helmet, armor, shoes, weapon
    public EquipmentList equipList;
    public string[] equipped = new string[4];

    void Start()
    {
        equipList = GameObject.FindObjectOfType<EquipmentList>();
        Debug.Log(equipList);
    }

    public EquippedItems(string helm, string armor, string leg, string weapon)
    {
        equipped[0] = helm;
        equipped[1] = armor;
        equipped[2] = leg;
        equipped[3] = weapon;
    }
}
