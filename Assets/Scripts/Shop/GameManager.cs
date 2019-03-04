using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
 //   public ItemsList holdItemDataBase;
 //   public ItemsList[] stuff;
 //   public PlayerInventory pInventory;
    public InventoryItems testItem;

    /*
    private void Awake()
    {
        MakeSingleton();
    }
    public void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            DontDestroyOnLoad(holdItemDataBase);
        }
    }
    */

    private void Awake()
    {
        testItem = gameObject.GetComponent<ItemsList>().GetByName("Sword");
    }

}
