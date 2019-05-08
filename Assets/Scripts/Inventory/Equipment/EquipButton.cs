using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipButton : MonoBehaviour
{
    Button button;

    void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(equipItem);
    }

    void equipItem()
    {
        EquipmentArmor itemToEquip = transform.parent.GetComponent<EquipArmorPanel>().itemToDisplay;
        string id = transform.parent.parent.GetComponent<EquipMenu>().id;
        int slot = transform.parent.parent.GetComponent<EquipMenu>().slot;
        EquippedItems equipped = FindObjectOfType<EquipDictionary>().dictionary[id];
        string itemToUnequip;

        // Set equipment name
        if (slot == 1)
        {
            itemToUnequip = equipped.helm;
            equipped.helm = itemToEquip.id;
        }
        else if (slot == 2)
        {
            itemToUnequip = equipped.armor;
            equipped.armor = itemToEquip.id;
        }
        else
        {
            itemToUnequip = equipped.pants;
            equipped.pants = itemToEquip.id;
        }
        // Update the EquipDictionary
        FindObjectOfType<EquipDictionary>().dictionary[id] = equipped;

        // Add the unequipped item back into inventory
        if(itemToUnequip != "helmetNothing" && itemToUnequip != "armorNothing" && itemToUnequip != "pantsNothing" && itemToUnequip != "weaponNothing")
            FindObjectOfType<PlayerInventory>().equipmentInventory.Add(FindObjectOfType<EquipmentDictionary>().armorDictionary[itemToUnequip]);

        // Remove equipped item from inventory
        FindObjectOfType<PlayerInventory>().equipmentInventory.Remove(FindObjectOfType<EquipmentDictionary>().armorDictionary[itemToEquip.id]);

        transform.parent.parent.parent.BroadcastMessage("updateButton");

        EquipCard[] cards = FindObjectsOfType<EquipCard>();
        for(int i = 0; i < cards.Length; i++)
        {
            cards[i].startGetStats();
        }

        Destroy(transform.parent.parent.gameObject);

    }
}
