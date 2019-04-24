using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class priceForms : MonoBehaviour {
    public ItemsList itemList;
	// Use this for initialization
	void Start () {
        itemName();
	}

    public void itemName()
    {
        gameObject.transform.Find("itemName").GetComponent<Text>().text = itemList.item[0].itemName;
    }

}
