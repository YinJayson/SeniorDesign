using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugGiveItem : MonoBehaviour
{
    public void giveItem(string itemName)
    {
        GameObject.FindObjectOfType<PlayerInventory>().itemObtained(itemName);
        Debug.Log("Giving " + itemName);
    }
}
