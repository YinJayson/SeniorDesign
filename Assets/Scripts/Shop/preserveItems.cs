using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class preserveItems : MonoBehaviour {
    // keep itemslist persistent, to be used by shop, playerinventory, etc
    public ItemsList itemsDatabase;
    private static bool created = false;

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            itemsDatabase = gameObject.AddComponent<ItemsList>();
        }
    }

    void Start()
        {
        if (!created)
        {
            Debug.Log(itemsDatabase.item.Count);
            created = true;
        }
    }
}
