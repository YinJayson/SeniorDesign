using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentButton : MonoBehaviour
{
    EquipmentItem itemToDisplay;
    Button button;
    public int slot;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(taskOnClick);
        updateButton();
    }

    public void updateButton()
    {
        if (slot == 1)
            itemToDisplay = FindObjectOfType<EquipmentDictionary>().armorDictionary[FindObjectOfType<EquipDictionary>().dictionary[transform.parent.parent.GetComponent<EquipCard>().id].helm];
        else if (slot == 2)
            itemToDisplay = FindObjectOfType<EquipmentDictionary>().armorDictionary[FindObjectOfType<EquipDictionary>().dictionary[transform.parent.parent.GetComponent<EquipCard>().id].armor];
        else if (slot == 3)
            itemToDisplay = FindObjectOfType<EquipmentDictionary>().armorDictionary[FindObjectOfType<EquipDictionary>().dictionary[transform.parent.parent.GetComponent<EquipCard>().id].pants];
        else if (slot == 4)
            itemToDisplay = FindObjectOfType<EquipmentDictionary>().weaponDictionary[FindObjectOfType<EquipDictionary>().dictionary[transform.parent.parent.GetComponent<EquipCard>().id].weapon];
        transform.Find("Sprite").GetComponent<Image>().sprite = itemToDisplay.sprite;
    }
    void taskOnClick()
    {
        GameObject menu = Instantiate(Resources.Load<GameObject>("Menus/EquipArmorMenu"), transform.parent.parent.parent) as GameObject;
        menu.GetComponent<EquipMenu>().id = transform.parent.parent.GetComponent<EquipCard>().id;
        menu.GetComponent<EquipMenu>().slot = slot;
    }
}
