
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

   
}
