using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class priceForms : MonoBehaviour {
    public ItemsList itemList;
    // Use this for initialization

    void Awake()
    {
        itemList = GameObject.FindObjectOfType<ItemsList>();
    }

    void Start () {
        itemName();
	}

    public void itemName()
    {
      
        Debug.Log("where am i");
        gameObject.transform.Find("itemName").GetComponent<Text>().text = itemList.item[0].itemName + itemList.item[0].itemPrice;
        //transform thik child
        GetComponent<Image>().sprite = itemList.item[0].sprite;
    }

}
