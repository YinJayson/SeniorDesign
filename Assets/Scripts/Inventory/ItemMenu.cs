using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMenu : MonoBehaviour
{
    public Inventory inventory;
    public int slot;

    void Start()
    {
        Debug.Log("Referencing slot " + slot);

        Item item = inventory.slots[slot];

        gameObject.transform.GetChild(0).GetComponent<Text>().text = item.id;
        gameObject.transform.GetChild(1).GetComponent<Text>().text = item.description;
        gameObject.transform.GetChild(2).GetComponent<Text>().text = item.value.ToString() + " Gold";
        gameObject.transform.GetChild(3).GetComponent<Text>().text = "x" + item.count;
    }

    public void deleteItem()
    {
        inventory.removeItem(slot);
        hideMenu();
    }

    public void hideMenu()
    {
        Destroy(gameObject);
    }
}
