using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatCard : MonoBehaviour
{
    public string id;

    public CharacterStats charStats;
    public CharacterDictionary dict;

    void Awake()
    {
        dict = GameObject.FindObjectOfType<CharacterDictionary>();
        charStats = dict.dictionary[id];
    }

    void Update()
    {
        getStats();
    }

    public void getStats()
    {
        charStats = dict.dictionary[id];

        gameObject.transform.GetChild(0).GetComponent<Text>().text = char.ToUpper(id[0]) + id.Substring(1);
        gameObject.transform.GetChild(1).GetComponent<Text>().text = "Level " + charStats.level;

        gameObject.transform.GetChild(2).GetComponent<Text>().text = "STR: " + charStats.strength;
        gameObject.transform.GetChild(3).GetComponent<Text>().text = "DEX: " + charStats.dex;
        gameObject.transform.GetChild(4).GetComponent<Text>().text = "INT: " + charStats.intelligence;
        gameObject.transform.GetChild(5).GetComponent<Text>().text = "Skill Points: " + charStats.skillPoints;

        gameObject.transform.GetChild(7).transform.GetChild(0).GetComponent<Image>().fillAmount = (float) charStats.exp / (float) charStats.expToLevel;
        gameObject.transform.GetChild(7).transform.GetChild(1).GetComponent<Text>().text = "<b>" + charStats.exp + " / " + charStats.expToLevel + "</b>";

        checkSP();
    }

    public void increaseStr()
    {
        charStats.strength++;
        charStats.skillPoints--;
        checkSP();
        dict.dictionary[id] = charStats;
    }
    public void increaseDex()
    {
        charStats.dex++;
        charStats.skillPoints--;
        checkSP();
        dict.dictionary[id] = charStats;
    }
    public void increaseInt()
    {
        charStats.intelligence++;
        charStats.skillPoints--;
        checkSP();
        dict.dictionary[id] = charStats;
    }

    void checkSP()
    {
        if (charStats.skillPoints <= 0)
            gameObject.transform.GetChild(6).gameObject.SetActive(false);
        else
            gameObject.transform.GetChild(6).gameObject.SetActive(true);
    }
}
