using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipArmorPanel : MonoBehaviour
{
    public EquipmentArmor itemToDisplay;

    public void setItem(string itemID)
    {
        itemToDisplay = FindObjectOfType<EquipmentDictionary>().armorDictionary[itemID];

        updatePanel();
    }

    public void updatePanel()
    {
        transform.Find("NameText").GetComponent<Text>().text = itemToDisplay.name;
        transform.Find("Sprite").GetComponent<Image>().sprite = itemToDisplay.sprite;
        transform.Find("Sprite").GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f);
        transform.Find("DescriptionText").GetComponent<Text>().text = itemToDisplay.description;
        transform.Find("ArmorText").GetComponent<Text>().text = "Armor: " + itemToDisplay.getDefense().ToString();
        transform.Find("ResistText").GetComponent<Text>().text = "Resist: " + itemToDisplay.getResist().ToString();
        transform.Find("ValueText").GetComponent<Text>().text = "Value: " + itemToDisplay.value.ToString();
    }
}
