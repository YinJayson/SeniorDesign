using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{

    public List<EquipmentInventory> playerEquipment = new List<EquipmentInventory>();
    //list with all possible items
    public EquipmentList equipList;

    //TODO
    //method nneeds to be changed to give player an item from winning combat needs to be implemented with combat system
    public void itemObtained(string equipName)
    {
        //locate the item in the Equipment List
        EquipmentInventory OBItem = equipList.GetByName(equipName);
        //add the located equipment into the player's equipment inventory
        playerEquipment.Add(OBItem);
    }

    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {

    }
}
