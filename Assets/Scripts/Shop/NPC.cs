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
  
    public ItemsList items;

    public int price;

    void Awake()
    {

    }

    // Use this for initialization
    void Start () {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
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

    public int count;
    public void Buy()
    {
        
        if(player.GetComponent<PlayerGold>().money >= price)
        {
            // get the items from the itemsList stuff, add price
            // add to player inventory
            
           
           player.GetComponent<PlayerInventory>().itemObtained("Sword");

            //   item = gameObject.GetComponent<ItemsList>().GetByName("Grenade");

            //    yield return new WaitUntil(() => frame >= 10);
       //     FindObjectOfType<GameManager>().loadItemDataBase();


       //     item = GetComponent<ItemsList>().GetByName("Sword");

           for (int i = 0; i < player.GetComponent<PlayerInventory>().playerItems.Count; i++)
        {
            Debug.Log(player.GetComponent<PlayerInventory>().playerItems[i].itemName);
        }

           player.GetComponent<PlayerGold>().money = player.GetComponent<PlayerGold>().money - price;
         
                
                
                //   Debug.Log(player.GetComponent<PlayerInventory>().playerItems[0].ToString());
        
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