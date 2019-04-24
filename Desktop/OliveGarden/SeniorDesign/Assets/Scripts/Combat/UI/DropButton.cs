using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropButton : MonoBehaviour
{
    InventoryItems itemToDisplay;

    public void setItem(InventoryItems item)
    {
        itemToDisplay = item;
        gameObject.GetComponent<Image>().sprite = itemToDisplay.sprite;//Resources.Load<Sprite>("Sprites/Items/" + item.sprite) as Sprite;
    }

    public void displayItemMenu()
    {
        if(itemToDisplay != null)
            Debug.Log(itemToDisplay.itemName);
    }
}
