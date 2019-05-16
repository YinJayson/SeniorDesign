using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipItemButton : MonoBehaviour
{
    public string itemID;

    int slot;
    Button button;
    EquipmentItem itemToDisplay;

    void Start()
    {
        slot = transform.parent.parent.GetComponent<EquipMenu>().slot;
    }

    void taskOnClick()
    {
        if(slot == 4)
            transform.parent.parent.Find("ToEquipPanel").GetComponent<EquipWeaponPanel>().setItem(itemID);
        else
            transform.parent.parent.Find("ToEquipPanel").GetComponent<EquipArmorPanel>().setItem(itemID);
    }

    public void setItem(string itemID)
    {
        this.itemID = itemID;
        displaySprite();
    }

    public void displaySprite()
    {
        if(slot == 4)   // Weapon
        {
            itemToDisplay = FindObjectOfType<EquipmentDictionary>().weaponDictionary[itemID];
            transform.Find("Sprite").GetComponent<Image>().sprite = itemToDisplay.sprite;
            button = GetComponent<Button>();
            button.onClick.AddListener(taskOnClick);
        }
        else
        {
            itemToDisplay = FindObjectOfType<EquipmentDictionary>().armorDictionary[itemID];
            transform.Find("Sprite").GetComponent<Image>().sprite = itemToDisplay.sprite;
            button = GetComponent<Button>();
            button.onClick.AddListener(taskOnClick);
        }
    }

}
