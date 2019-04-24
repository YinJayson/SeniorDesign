using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class preserveItems : MonoBehaviour {
    // keep itemslist persistent, to be used by shop, playerinventory, etc
    public ItemsList itemsDatabase;
    public PlayerInventory playerIntv;
    private static bool created = false;

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            itemsDatabase = gameObject.AddComponent<ItemsList>();
            playerIntv = gameObject.AddComponent<PlayerInventory>();
        }
    }

    void Start()
        {
        if (!created)
        {
            Debug.Log(itemsDatabase.item.Count);
            for (int i = 0; i < itemsDatabase.item.Count; i++)
            {
                Debug.Log(itemsDatabase.item[i].itemName);
            }
            Debug.Log(playerIntv.playerItems.Count);
            created = true;
        }
    }
}
