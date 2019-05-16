using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Item
{
    //item attributes
    public string id;
    public string name;
    public string description;
    public int value;
    public bool stacks;
    public int count { get; set; }
    public Sprite sprite;
    
    public Item()
    {
        this.name = "";
        this.description = "";
        this.value = 0;
        this.stacks = false;
        this.count = 0;
    }
    public Item(string name, string description, int value, bool stacks, int stacksCount, string spriteName)
    {
        this.name = name;
        this.description = description;
        this.value = value;
        this.stacks = stacks;
        if (!stacks)
            this.count = 1;
        else
            this.count = stacksCount;
        this.sprite = Resources.Load<Sprite>("Sprites/Items/" + spriteName) as Sprite;
    }
}
