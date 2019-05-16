using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{

    public List<EquipmentItem> playerEquipment = new List<EquipmentItem>();
    public EquipmentList equipmentList;

    //Connected to combat this is method used when its one by combat
    public void equipmentObtained(string equipName)
    {
        //EquipmentItem OBItem = equipmentList.GetByName(equipName);
        //playerEquipment.Add(OBItem);
    }

    /*
    public EquipmentItem GetByName(string equipName)
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
    */
}
