using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Item[] slots;

	void Start()
    {
        slots = new Item[8];
	}

    public void showMenu(int slot)
    {
        if (slots[slot] != null)
        {
            GameObject itemMenu;

            if (GameObject.FindGameObjectWithTag("ItemMenu") != null)
                itemMenu = GameObject.FindGameObjectWithTag("ItemMenu");
            else
                itemMenu = Instantiate(Resources.Load("Menus/ItemMenu") as GameObject, new Vector2(125, 0), Quaternion.identity, GameObject.FindGameObjectWithTag("InventoryCanvas").transform);

            itemMenu.GetComponent<ItemMenu>().inventory = this;
            itemMenu.GetComponent<ItemMenu>().slot = slot;
        }
    }

    public void addItem(Item itemToAdd)
    {
        bool itemAdded = false;

        for (int i = 0; i < slots.Length; i++)
            if (slots[i] == null)
            {
                slots[i] = itemToAdd;
                gameObject.transform.GetChild(i).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Items/" + itemToAdd.sprite) as Sprite;
                Debug.Log("Sprites/" + itemToAdd.sprite);
                itemAdded = true;
                break;
            }

        if (!itemAdded)
            Debug.Log("Inven full, item tossed");
    }

    public void removeItem(int slot)
    {
        if (slots[slot] != null)
        {
            slots[slot] = null;
            gameObject.transform.GetChild(slot).GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Background") as Sprite;
        }
    }
}
