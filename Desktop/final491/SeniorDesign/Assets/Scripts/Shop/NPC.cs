using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameObject player;
    public GameObject canvas;
    private bool triggerPlayer;
    private bool shopTrigger;

    // Update is called once per frame
    void Update()
    {
        // activate/deactive both shop canvas and playermovement respectively
        if (shopTrigger)
        {
            canvas.SetActive(true);
            player.GetComponent<PlayerController>().enabled = false;
        }
        else
            canvas.SetActive(false);
            player.GetComponent<PlayerController>().enabled = true;
        if (triggerPlayer)
        {
            if (Input.GetKeyDown(KeyCode.E))
                shopTrigger = !shopTrigger;
        }
    }

    public void itemsFromItemsList(string item)
    {
    //    Debug.Log(item);
        if (item == FindObjectOfType<ItemsList>().GetByName(item).itemName)
        {
            if (FindObjectOfType<PlayerInventory>().gold >= FindObjectOfType<ItemsList>().GetByName(item).itemPrice)
            {
                FindObjectOfType<PlayerInventory>().itemBought(item);
                FindObjectOfType<PlayerInventory>().gold = FindObjectOfType<PlayerInventory>().gold - FindObjectOfType<ItemsList>().GetByName(item).itemPrice;
            //    Debug.Log(FindObjectOfType<PlayerInventory>().playerItems);
            }
            else
            {
                print("Not enough gold, customer");
            }
        }
    }

    public void itemsFromEquipmentDictionary(string item)
    {
    //    Debug.Log(item);
        if (FindObjectOfType<EquipmentDictionary>().armorDictionary.ContainsKey(item))
        {
            if (FindObjectOfType<PlayerInventory>().gold >= FindObjectOfType<EquipmentDictionary>().armorDictionary[item].value)
            {
                FindObjectOfType<PlayerInventory>().giveEquipmentArmor(item);
                FindObjectOfType<PlayerInventory>().gold = FindObjectOfType<PlayerInventory>().gold - FindObjectOfType<EquipmentDictionary>().armorDictionary[item].value;
            }
            else
            {
                print("Not enough gold, customer");
            }
        }
    }


    // simple collision functions so npc and player can interact
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            triggerPlayer = true;
            Debug.Log("Player entered npc hitbox");
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            triggerPlayer = false;
            Debug.Log("Player exited npc hitbox");
        }
    }
}