using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    public int slotNum;

    InventoryItems itemToDisplay;
    PlayerInventory inventory;

    void OnEnable()
    {
        inventory = FindObjectOfType<PlayerInventory>();
        if (inventory.playerItems.Count > slotNum && inventory.playerItems[slotNum] != null)
        {
            setItem(inventory.playerItems[slotNum]);
        }
    }
    public void setItem(InventoryItems item)
    {
        itemToDisplay = item;
        transform.Find("Sprite").GetComponent<Image>().sprite = itemToDisplay.sprite;//Resources.Load<Sprite>("Sprites/Items/" + item.sprite) as Sprite;
    }

    public void displayItemMenu()
    {
        if (itemToDisplay != null)
            Debug.Log(itemToDisplay.itemName);
    }
}
