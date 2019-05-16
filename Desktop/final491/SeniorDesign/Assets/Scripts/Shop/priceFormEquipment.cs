using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class priceFormEquipment : MonoBehaviour {

    void Start() {
        itemName(gameObject.GetComponentInChildren<Text>().text);
    }

    public void itemName(string item)
    {
        Debug.Log(FindObjectOfType<EquipmentDictionary>().armorDictionary[item].id);
        gameObject.transform.Find("Text").GetComponent<Text>().text = FindObjectOfType<EquipmentDictionary>().armorDictionary[item].name + " Price: " + FindObjectOfType<EquipmentDictionary>().armorDictionary[item].value + "G" + " Desc: " + FindObjectOfType<EquipmentDictionary>().armorDictionary[item].description;
        GetComponent<Image>().sprite = FindObjectOfType<EquipmentDictionary>().armorDictionary[item].sprite;
    }
}
