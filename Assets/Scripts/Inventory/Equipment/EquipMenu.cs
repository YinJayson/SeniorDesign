using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipMenu : MonoBehaviour
{
    public string id = null;
    public int slot = 0;

    void OnEnable()
    {
        StartCoroutine(updatePanel());
    }

    IEnumerator updatePanel()
    {
        yield return new WaitUntil(() => id != null && slot != 0);
        if (slot == 1)
            transform.Find("EquippedPanel").GetComponent<EquipArmorPanel>().setItem(FindObjectOfType<EquipDictionary>().dictionary[id].helm);
        else if (slot == 2)
            transform.Find("EquippedPanel").GetComponent<EquipArmorPanel>().setItem(FindObjectOfType<EquipDictionary>().dictionary[id].armor);
        else if (slot == 3)
            transform.Find("EquippedPanel").GetComponent<EquipArmorPanel>().setItem(FindObjectOfType<EquipDictionary>().dictionary[id].pants);
        else if (slot == 4)
            transform.Find("EquippedPanel").GetComponent<EquipWeaponPanel>().setItem(FindObjectOfType<EquipDictionary>().dictionary[id].weapon);
        updateButtons();
    }

    void updateButtons()
    {
        PlayerInventory inventory = FindObjectOfType<PlayerInventory>();

        if (slot == 1)
            transform.Find("Buttons").GetChild(0).GetComponent<EquipItemButton>().setItem("helmetNothing");
        else if (slot == 2)
            transform.Find("Buttons").GetChild(0).GetComponent<EquipItemButton>().setItem("armorNothing");
        else if (slot == 3)
            transform.Find("Buttons").GetChild(0).GetComponent<EquipItemButton>().setItem("pantsNothing");
        else if (slot == 4)
            transform.Find("Buttons").GetChild(0).GetComponent<EquipItemButton>().setItem("weaponNothing");

        int buttonOffset = 1;
        for (int i = 0; i < inventory.equipmentInventory.Count && buttonOffset < 12; i++)
        {
            Debug.Log(inventory.equipmentInventory[i].slot + " == " + slot);
            if (inventory.equipmentInventory[i].slot == slot)
            {
               transform.Find("Buttons").GetChild(buttonOffset).GetComponent<EquipItemButton>().setItem(inventory.equipmentInventory[i].id);
               buttonOffset++;
            }
        }
    }
}
