using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryMenu : MonoBehaviour
{
    void OnEnable()
    {
        BroadcastMessage("updateButton");
        transform.Find("GoldText").GetComponent<Text>().text = "Gold: " + FindObjectOfType<PlayerInventory>().gold.ToString();
    }
}
