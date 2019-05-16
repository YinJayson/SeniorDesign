using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerGoldandItem : MonoBehaviour {

	void Start () {
        playerGold();

    }

    void Update () {
        playerGold();
    }

    public void playerGold()
    {
        gameObject.GetComponentInChildren<Text>().text = "Player Gold: " + FindObjectOfType<PlayerInventory>().gold.ToString();
    }
}
