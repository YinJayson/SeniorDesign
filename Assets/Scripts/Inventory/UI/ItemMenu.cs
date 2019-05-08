using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMenu : MonoBehaviour
{
    public int slotNum;

    InventoryItems itemToDisplay;

    void Start()
    {
        updateMenu();
    }

    public void updateMenu()
    {
        itemToDisplay = FindObjectOfType<PlayerInventory>().playerItems[slotNum];
        transform.Find("NameText").GetComponent<Text>().text = itemToDisplay.itemName;
        transform.Find("DescriptionText").GetComponent<Text>().text = itemToDisplay.itemDescription;
    }

    public void destroyMenu()
    {
        Destroy(gameObject);
    }

    public void removeItem()
    {
        FindObjectOfType<PlayerInventory>().playerItems[slotNum] = null;
        transform.parent.BroadcastMessage("updateButton");
        destroyMenu();
    }
}
