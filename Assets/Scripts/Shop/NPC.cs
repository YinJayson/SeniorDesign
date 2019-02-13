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

    public GameObject item;

    public InventoryItems weaponTest;

    public int price;

	// Use this for initialization
	void Start () {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        weaponTest = GetComponent<InventoryItems>();
    }

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

     
            Transform itemTest = Instantiate(item.transform, player.transform.position, Quaternion.identity);
            itemTest.gameObject.SetActive(false);
            itemTest.parent = player.transform;
            player.GetComponent<PlayerGold>().money -= price;

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
