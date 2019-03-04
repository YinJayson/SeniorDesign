using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour {
    public Button button;
    public GameObject player;
    public GameObject canvas;

    private bool triggerPlayer;
    private bool shopTrigger;
  
    public InventoryItems item;
    public ItemsList instance;
    public PlayerInventory playerInventory;

    // InventoryItems test3 = Object.FindObjectOfType<InventoryItems>();

    public int price;

    public int frame;

    void Awake()
    {
 
    //    InventoryItems Grenade = gameObject.GetComponent<ItemsList>().GetByName("Grenade");
    }

    // Use this for initialization
    void Start () {
    //    StartCoroutine(example());
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    /*
    IEnumerator example()
    {
        Debug.Log("Waiting for princess to be rescued...");
        yield return new WaitUntil(() => frame >= 10);
        Debug.Log("Princess was rescued!");
    }
    */

    // Update is called once per frame
    void Update () {
        if (shopTrigger)
            canvas.SetActive(true);
        else
            canvas.SetActive(false);

	    if(triggerPlayer)
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
            Buy();
        }
    }

    public void Buy()
    {
        if(player.GetComponent<PlayerGold>().money >= price)
        {
            // get the items from the itemsList stuff, add price
            // add to player inventory

            //    player.GetComponent<PlayerInventory>().itemBought("Grenade");

            //   item = gameObject.GetComponent<ItemsList>().GetByName("Grenade");

            //    yield return new WaitUntil(() => frame >= 10);

            item = GetComponent<ItemsList>().GetByName("Sword");

            Debug.Log("see");
        } else
        {
            print("not enough gold peasant.");
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            triggerPlayer = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            triggerPlayer = false;
        }
    }
}