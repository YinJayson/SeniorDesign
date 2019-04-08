using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{

    public List<EquipmentInventory> playerEquipment = new List<EquipmentInventory>();
    public EquipmentList equipmentList;

    public void equipmentObtained(string equipName)
    {
        EquipmentInventory OBItem = equipmentList.GetByName(equipName);
        playerEquipment.Add(OBItem);
    }

    public EquipmentInventory GetByName(string equipName)
    {
        for (int i = 0; i < playerEquipment.Count; i++)
        {
            if (playerEquipment[i].equipName == equipName)
            {
                return playerEquipment[i];
            }
        }
        return null;
    }
}
