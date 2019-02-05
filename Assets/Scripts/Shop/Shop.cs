using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

    public Button button;
    public GameObject player;
    public GameObject canvas;

    private bool triggerPlayer;
    private bool shopTrigger;

    public GameObject item;
    public int price;

	// Use this for initialization
	void Start () {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(clickOnShop);
	}

	// Update is called once per frame
	void Update () {

        if (shopTrigger)
            canvas.SetActive(true);
        else
            canvas.SetActive(false);

	    if(triggerPlayer)
        {
            if (Input.GetKeyDown(KeyCode.E))
                shopTrigger = !shopTrigger;
        }
	}

    public void clickOnShop()
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
