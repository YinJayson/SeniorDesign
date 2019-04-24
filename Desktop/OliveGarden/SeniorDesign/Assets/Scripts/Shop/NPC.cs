using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    // for each item, make button...
    //    public Button button2, button3, button4, button5;
 //   public Button button;
//    public Button[] button;
//    public Button[] bt;
    public GameObject player;
    public GameObject canvas;
    private bool triggerPlayer;
    private bool shopTrigger;
    public ItemsList items;
    // public int price;

    public static bool created = false;

    // Use this for initialization
    void Start()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);

            items = FindObjectOfType<ItemsList>();
            created = true;
        }
    }

    // might create a separate database just for items in shop
    public void createButtons()
    {
        /*
        for (int i = 0; i < gameObject.GetComponent<ItemsList>().item.Count; i++)
        {
            bt[i] = button[i].GetComponent<Button>();
            button[i].onClick.AddListener(TaskOnClick);
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
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
            // have to be within the NPC to turn enter/exit out of the canvas, fix this 
            // player stands still being in the shop canvas
            if (Input.GetKeyDown(KeyCode.E))
                shopTrigger = !shopTrigger;
        }
    }

    public void TaskOnClick()
    {
        if (shopTrigger)
        {
         //   Buy();
       
        }
    }

    public void tests(string thing)
    {
        // dont need else ifs
        if (thing == GetComponent<ItemsList>().GetByName("Sword").itemName)
        {
            if (player.GetComponent<PlayerGold>().money >= gameObject.GetComponent<ItemsList>().GetByName("Sword").itemPrice)
            {
                player.GetComponent<PlayerInventory>().itemObtained(thing);
                player.GetComponent<PlayerGold>().money = player.GetComponent<PlayerGold>().money - gameObject.GetComponent<ItemsList>().GetByName("Sword").itemPrice;
            } else
            {
                print("Not enough gold, customer");
            }
        } else if (thing == gameObject.GetComponent<ItemsList>().GetByName("Health Potion").itemName)
        {
            if (player.GetComponent<PlayerGold>().money >= gameObject.GetComponent<ItemsList>().GetByName("Sword").itemPrice)
            {
                player.GetComponent<PlayerInventory>().itemObtained("Health Potion");
                player.GetComponent<PlayerGold>().money = player.GetComponent<PlayerGold>().money - gameObject.GetComponent<ItemsList>().GetByName("Sword").itemPrice;
            }
            else
            {
                print("Not enough gold, customer");
            }
        } else if (thing == gameObject.GetComponent<ItemsList>().GetByName("Grenade").itemName)
        {
            if (player.GetComponent<PlayerGold>().money >= gameObject.GetComponent<ItemsList>().GetByName("Grenade").itemPrice)
            {
                player.GetComponent<PlayerInventory>().itemObtained("Grenade");
                player.GetComponent<PlayerGold>().money = player.GetComponent<PlayerGold>().money - gameObject.GetComponent<ItemsList>().GetByName("Grenade").itemPrice;
            }
            else
            {
                print("Not enough gold, customer");
            }
        }
    }

    public void sellMyItem()
    {
        Debug.Log("er");
    }
    /*
    public void Buy()
    {
        // gameobject.GetComponentNPCITEMPRICES for said item
        if (player.GetComponent<PlayerGold>().money >= price)
        {
            // get the items from the itemsList stuff, add price
            // add to player inventory
            // add if statements for different items
            player.GetComponent<PlayerInventory>().itemObtained("Sword");
           
            // comment the for loop

            for (int i = 0; i < player.GetComponent<PlayerInventory>().playerItems.Count; i++)
         {
             Debug.Log(player.GetComponent<PlayerInventory>().playerItems[i].itemName);
         }
            
            player.GetComponent<PlayerGold>().money = player.GetComponent<PlayerGold>().money - price;

        }
        else
        {
            print("not enough gold peasant.");
        }
    }
    */
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            triggerPlayer = true;
            Debug.Log("enter should be stopped");
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            triggerPlayer = false;
        //    player.GetComponent<PlayerController>().enabled = true;
            Debug.Log("exit should be able to move");
        }
    }
}