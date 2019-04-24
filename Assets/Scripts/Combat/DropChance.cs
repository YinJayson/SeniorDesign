using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropChance
{
    // By default, nothing will drop
    float dropWeightNothing = 1.0f;
    string item1 = "";
    float dropWeight1 = 0.0f;
    string item2 = "";
    float dropWeight2 = 0.0f;
    string item3 = "";
    float dropWeight3 = 0.0f;
    string item4 = "";
    float dropWeight4 = 0.0f;

    /* Constructors */
    /* Multiple constructors are for when there are less item chances than needed
     * Because default is that nothing will drop, items can be added as necessary
     */
    public DropChance()
    {

    }
    public DropChance(float dropWeightNothing, string item1, float dropWeight1)
    {
        this.dropWeightNothing = dropWeightNothing;
        this.item1 = item1;
        this.dropWeight1 = dropWeight1;
    }
    public DropChance(float dropWeightNothing, string item1, float dropWeight1, string item2, float dropWeight2)
    {
        this.dropWeightNothing = dropWeightNothing;
        this.item1 = item1;
        this.dropWeight1 = dropWeight1;
        this.item2 = item2;
        this.dropWeight2 = dropWeight2;
    }
    public DropChance(float dropWeightNothing, string item1, float dropWeight1, string item2, float dropWeight2, string item3, float dropWeight3)
    {
        this.dropWeightNothing = dropWeightNothing;
        this.item1 = item1;
        this.dropWeight1 = dropWeight1;
        this.item2 = item2;
        this.dropWeight2 = dropWeight2;
        this.item3 = item3;
        this.dropWeight3 = dropWeight3;
    }
    public DropChance(float dropWeightNothing, string item1, float dropWeight1, string item2, float dropWeight2, string item3, float dropWeight3, string item4, float dropWeight4)
    {
        this.dropWeightNothing = dropWeightNothing;
        this.item1 = item1;
        this.dropWeight1 = dropWeight1;
        this.item2 = item2;
        this.dropWeight2 = dropWeight2;
        this.item3 = item3;
        this.dropWeight3 = dropWeight3;
        this.item4 = item4;
        this.dropWeight4 = dropWeight4;
    }

    public InventoryItems getDrop()
    {
        int dropNum = Mathf.RoundToInt(Random.Range(1.0f, dropWeightNothing + dropWeight1 + dropWeight2 + dropWeight3 + dropWeight4));
        Debug.Log("num = " + dropNum);
        Debug.Log(dropWeightNothing + " | " + dropWeight1 + " | " + dropWeight2 + " | " + dropWeight3 + " | " + dropWeight4);
        // Item drop chance: Exclusive beginning number, inclusive ending number

        if (dropNum <= dropWeightNothing)
        {
            Debug.Log("Dropped nothing");
            return null;
        }
        else if (dropNum > dropWeightNothing && dropNum <= dropWeightNothing + dropWeight1)
        {
            Debug.Log("Dropped " + item1);
            return GameObject.FindObjectOfType<ItemsList>().GetByName(item1);
        }
        else if (dropNum > dropWeightNothing + dropWeight1 && dropNum <= dropWeightNothing + dropWeight1 + dropWeight2)
            return GameObject.FindObjectOfType<ItemsList>().GetByName(item2);
        else if (dropNum > dropWeightNothing + dropWeight1 + dropWeight2 && dropNum <= dropWeightNothing + dropWeight1 + dropWeight2 + dropWeight3)
            return GameObject.FindObjectOfType<ItemsList>().GetByName(item3);
        else if (dropNum > dropWeightNothing + dropWeight1 + dropWeight2 + dropWeight3 && dropNum <= dropWeightNothing + dropWeight1 + dropWeight2 + dropWeight3 + dropWeight4)
            return GameObject.FindObjectOfType<ItemsList>().GetByName(item4);

        Debug.Log("Something went wrong in DropChance: Weights were bypassed");
        return null;
    }
}
