using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class priceFormItemsList : MonoBehaviour {

    void Start()
    {
        itemName(gameObject.GetComponentInChildren<Text>().text);
    }

    public void itemName(string thing)
    {
        for (int i = 0; i < FindObjectOfType<ItemsList>().item.Count; i++) {
            if (thing == FindObjectOfType<ItemsList>().item[i].itemName)
            {
                gameObject.transform.Find("itemName").GetComponent<Text>().text = FindObjectOfType<ItemsList>().item[i].itemName + " Price: " + FindObjectOfType<ItemsList>().item[i].itemPrice + "G" + " Desc: " + FindObjectOfType<ItemsList>().item[i].itemDescription;
                GetComponent<Image>().sprite = FindObjectOfType<ItemsList>().item[i].sprite;
            }
        }
    }
}
