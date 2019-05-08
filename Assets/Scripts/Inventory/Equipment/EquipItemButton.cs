using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipItemButton : MonoBehaviour
{
    public string itemID;

    Button button;
    EquipmentArmor itemToDisplay;

    void taskOnClick()
    {
        transform.parent.parent.Find("ToEquipPanel").GetComponent<EquipArmorPanel>().setItem(itemID);
    }

    public void setItem(string itemID)
    {
        this.itemID = itemID;
        displaySprite();
    }

    public void displaySprite()
    {
        itemToDisplay = FindObjectOfType<EquipmentDictionary>().armorDictionary[itemID];
        transform.Find("Sprite").GetComponent<Image>().sprite = itemToDisplay.sprite;
        button = GetComponent<Button>();
        button.onClick.AddListener(taskOnClick);
    }

}
