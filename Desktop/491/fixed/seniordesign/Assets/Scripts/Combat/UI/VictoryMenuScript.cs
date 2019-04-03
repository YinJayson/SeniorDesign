using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryMenuScript : MonoBehaviour
{
    public void setGoldGained(int gold)
    {
        gameObject.transform.Find("ResourceGainedMenu").transform.Find("GoldText").GetComponent<Text>().text = "Gold Gained: " + gold;
    }
    public void setEXPGained(int exp)
    {
        gameObject.transform.Find("ResourceGainedMenu").transform.Find("EXPText").GetComponent<Text>().text = "EXP Gained: " + exp;
    }
    public void dropItems(string id1, string id2, string id3)
    {
        PlayerInventory inventory = GameObject.FindObjectOfType<PlayerInventory>();

        InventoryItems item1 = GameObject.FindObjectOfType<DropDictionary>().dictionary["slime"].getDrop();
        InventoryItems item2 = GameObject.FindObjectOfType<DropDictionary>().dictionary["slime"].getDrop();
        InventoryItems item3 = GameObject.FindObjectOfType<DropDictionary>().dictionary["slime"].getDrop();

        if (item1 != null)
        {
            inventory.itemObtained(item1.itemName);
            gameObject.transform.Find("DropMenu").transform.Find("Button1").GetComponent<DropButton>().setItem(item1);
        }
            if (item2 != null)
        {
            inventory.itemObtained(item2.itemName);
            gameObject.transform.Find("DropMenu").transform.Find("Button2").GetComponent<DropButton>().setItem(item2);
        }
        if (item3 != null)
        {
            inventory.itemObtained(item3.itemName);
            gameObject.transform.Find("DropMenu").transform.Find("Button3").GetComponent<DropButton>().setItem(item3);
        }
    }
}
