using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugAddItem : MonoBehaviour
{
    public Inventory inventory;

    public void addItemSlime()
    {
        Item itemToAdd = new Item("Slime", 10, 1, true, "It's slime", "Slime");
        inventory.addItem(itemToAdd);
    }
    public void addItemPotion()
    {
        Item itemToAdd = new Item("Potion", 15, 1, true, "Drink to feel better", "HealthPotion");
        inventory.addItem(itemToAdd);
    }
}
