using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryButton : MonoBehaviour
{
    public int slotNum;

    static GameObject itemMenu;

    PlayerInventory inventory;

    public void updateButton()
    {
        inventory = FindObjectOfType<PlayerInventory>();

        if (inventory.playerItems.Count > slotNum && inventory.playerItems[slotNum] != null)
            transform.Find("Sprite").GetComponent<Image>().sprite = inventory.playerItems[slotNum].sprite;
        else
            transform.Find("Sprite").GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Outline") as Sprite;
    }

    public void displayItemMenu()
    {
        if (inventory.playerItems.Count > slotNum && inventory.playerItems[slotNum] != null)
        {
            if(itemMenu == null)
                itemMenu = Instantiate(Resources.Load("Menus/ItemMenu") as GameObject, transform.parent);

            itemMenu.GetComponent<ItemMenu>().slotNum = slotNum;
            itemMenu.GetComponent<ItemMenu>().updateMenu();
        }
    }
}
