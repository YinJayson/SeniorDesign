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

        List<InventoryItems> items = new List<InventoryItems>();

        for(int i = 0; i < Mathf.RoundToInt(Random.Range(1.0f, 8.0f)); i++)
        {
            int idToDrop = Mathf.RoundToInt(Random.Range(0.0f, 2.0f));
            InventoryItems itemDrop;

            if (idToDrop == 0)
            {
                itemDrop = GameObject.FindObjectOfType<DropDictionary>().dictionary[id1].getDrop();
            }
            else if (idToDrop == 1)
            {
                itemDrop = GameObject.FindObjectOfType<DropDictionary>().dictionary[id2].getDrop();
            }
            else
            {
                itemDrop = GameObject.FindObjectOfType<DropDictionary>().dictionary[id3].getDrop();
            }

            if (itemDrop != null)
            {
                items.Add(itemDrop);
            }
        }

        Debug.Log("Count = " + items.Count);
        for(int i = 0; i < items.Count; i++)
        {
            inventory.itemObtained(items[i].itemName);
            transform.Find("DropMenu").GetChild(i).GetComponent<DropButton>().setItem(items[i]);
        }
        
        /*
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
        */
    }
}
