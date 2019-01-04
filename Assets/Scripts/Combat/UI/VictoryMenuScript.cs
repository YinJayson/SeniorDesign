using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryMenuScript : MonoBehaviour
{
    public void setGoldGained(int gold)
    {
        gameObject.transform.GetChild(2).GetChild(0).GetComponent<Text>().text = "Gold Gained: " + gold;
        Debug.Log("A");
    }
    public void setEXPGained(int exp)
    {
        gameObject.transform.GetChild(2).GetChild(1).GetComponent<Text>().text = "EXP Gained: " + exp;
    }
}
