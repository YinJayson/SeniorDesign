/*
 
    USE SCENE MAIN1 FOR WORKING INVENTORY
 
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<InventoryItems> playerItems = new List<InventoryItems>();
    public List<EquipmentItem> equipmentInventory = new List<EquipmentItem>();
    //list with all possible items
    public ItemsList itemList;
    public int gold;

    private static bool created = false;

    void Start()
    {
        if(!created)
        {
            DontDestroyOnLoad(this.gameObject);

            itemList = FindObjectOfType<ItemsList>();

            equipmentInventory.Add(FindObjectOfType<EquipmentDictionary>().armorDictionary["armorCotton"]);
            equipmentInventory.Add(FindObjectOfType<EquipmentDictionary>().armorDictionary["armorLeather"]);

            created = true;
        }
    }

    //TODO
    //method nneeds to be changed to give player an item from winning combat needs to be implemented with combat system
    public void itemObtained(string itemName) {
        //locate the item in the Inventory items List
        //var OBItem = itemList.GetByName(itemName);
        InventoryItems OBItem = itemList.GetByName(itemName);
        //add the located item into the player's inventory
        playerItems.Add(OBItem);
        //Debug.Log(OBItem.itemName);
        //Debug.Log(OBItem.itemDescription);
        //inventoryUI.AddItem(OBItem);
    }

    /* TODO:
     proably need a separate method for when the item is bought
     not completely sure how much it will be altered
     "place holder method" to rememeber to implement it
     */
    public void itemBought(string itemName) {
        //locate the item in the Inventory items List
        InventoryItems BOItem = itemList.GetByName(itemName);
        //add the located item into the player's inventory
        playerItems.Add(BOItem);
    }
    public InventoryItems GetByName(string itemName)
    {

        for (int i = 0; i < playerItems.Count; i++)
        {
            if (playerItems[i].itemName == itemName)
            {
                return playerItems[i];
                //Debug.Log(playerItems[i].itemName);
            }
        }
        return null;
    }

    public void giveEquipmentArmor(string id)
    {
        if (FindObjectOfType<EquipmentDictionary>().armorDictionary.ContainsKey(id))
            equipmentInventory.Add(FindObjectOfType<EquipmentDictionary>().armorDictionary[id]);
        else
            Debug.Log("Could not find " + id + " in armorDictionary");
    }

    
    //method to remove item
    //Delete button
   
   /* public void deleteItem(string itemName) {
        InventoryItems delItem = playerItems.GetByName(itemName);
        playerItems.Remove(delItem);
        //Debug.Log(delItem.itemName + " Deleted");
    }*/
    
    /* TODO */
    //make the player able to use item
    //connect with player stats
    // Use this for initialization
}
