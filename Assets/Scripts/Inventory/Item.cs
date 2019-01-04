using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string id;
    public int value;
    public int count;
    public bool stackable;
    public string description;
    public string sprite;

    public Item(string i, int v, int c, bool stack, string d, string spriteName)
    {
        id = i;
        value = v;
        count = c;
        stackable = stack;
        description = d;
        sprite = spriteName;
    }
}
