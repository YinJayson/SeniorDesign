
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{

    public InventoryItems inventoryItem;//setters and getters
    public Image itemImage;
    public GameObject inventory;
    public Transform slotPanel;
    public ItemsList itemList;
    public GameObject Slots;
    public GameObject item;
    public int inventorySlots;
    public List<InventoryUI> ItemsUI = new List<InventoryUI>();

    private void Awake()
    {
        itemImage = GetComponent<Image>();
        inventorySlots = 24;

        for (int i = 0; i < inventorySlots; i++) {
            GameObject instance = Instantiate(Slots);
            instance.transform.SetParent(slotPanel);

        }
    }

    /*private void Awake()
    {
        //Fetch the Image from the GameObject
        itemImage = GetComponent<Image>();
        SetItem(null);
        //itemName.text = "Life Potion";
        for (int i = 0; i < inventorySlots; i++) {
            GameObject instance = Instantiate(slot);
            instance.transform.SetParent(slots);
            ItemsUI.Add(instance.GetComponentInChildren<InventoryUI>());
        }
 
    }

    public void SetItem(InventoryItems inventoryItem) {
        this.inventoryItem = inventoryItem;
        if (this.inventoryItem != null)
        {
            itemImage.color = Color.white;
            itemImage.sprite = this.inventoryItem.sprite;

        }
        else {
            itemImage.color = Color.clear;
        }
        //itemImage.sprite = this.inventoryItem.sprite;
    }
    public void setSlot(int slot, InventoryItems inventoryItem) {
        ItemsUI[slot].SetItem(inventoryItem);
    }
    public void AddItem(InventoryItems inventoryItem) {
        setSlot(ItemsUI.FindIndex(i => i.ItemsUI == null), inventoryItem);
    }


    */
}