using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipWeaponPanel : MonoBehaviour
{
    public EquipmentWeapon itemToDisplay;

    public void setItem(string itemID)
    {
        itemToDisplay = FindObjectOfType<EquipmentDictionary>().weaponDictionary[itemID];

        updatePanel();
    }

    public void updatePanel()
    {
        transform.Find("NameText").GetComponent<Text>().text = itemToDisplay.name;
        transform.Find("Sprite").GetComponent<Image>().sprite = itemToDisplay.sprite;
        transform.Find("Sprite").GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f);
        transform.Find("DescriptionText").GetComponent<Text>().text = itemToDisplay.description;
        transform.Find("AttackText").GetComponent<Text>().text = "Attack: " + itemToDisplay.getAttack().ToString();

        if(itemToDisplay.id == "weaponNothing")
            transform.Find("AtkTypeText").GetComponent<Text>().text = "Atk Type: Default";
        else if (itemToDisplay.getAtkType())  // Physical
            transform.Find("AtkTypeText").GetComponent<Text>().text = "Atk Type: Physical";
        else
            transform.Find("AtkTypeText").GetComponent<Text>().text = "Atk Type: Magical";

        transform.Find("ValueText").GetComponent<Text>().text = "Value: " + itemToDisplay.value.ToString();
    }
}
