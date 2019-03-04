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

    void Start()
    {
        gameObject.transform.Find("NameText").GetComponent<Text>().text = char.ToUpper(id[0]) + id.Substring(1);
        getStats();
    }

    void checkSP()
    {
        if (charStats.skillPoints <= 0)
            gameObject.transform.Find("Buttons").gameObject.SetActive(false);
        else
            gameObject.transform.Find("Buttons").gameObject.SetActive(true);
    }

    public IEnumerator getStats()
    {
        yield return new WaitUntil(() => dict != null);
        gameObject.transform.Find("LevelText").GetComponent<Text>().text = "Level " + charStats.level;

        gameObject.transform.Find("StrengthText").GetComponent<Text>().text = "STR: " + charStats.strength;
        gameObject.transform.Find("DexText").GetComponent<Text>().text = "DEX: " + charStats.dex;
        gameObject.transform.Find("IntText").GetComponent<Text>().text = "INT: " + charStats.intelligence;
        gameObject.transform.Find("PointsText").GetComponent<Text>().text = "Skill Points: " + charStats.skillPoints;

        gameObject.transform.Find("EXPBar").Find("EXPBarFilling").GetComponent<Image>().fillAmount = (float) charStats.exp / (float) charStats.expToLevel;
        gameObject.transform.Find("EXPBar").Find("EXPText").GetComponent<Text>().text = "<b>" + charStats.exp + " / " + charStats.expToLevel + "</b>";

        checkSP();
    }

    public void increaseStr()
    {
        charStats.strength++;
        charStats.skillPoints--;
        checkSP();
        dict.dictionary[id] = charStats;
        StartCoroutine(getStats());
    }
    public void increaseDex()
    {
        charStats.dex++;
        charStats.skillPoints--;
        checkSP();
        dict.dictionary[id] = charStats;
        StartCoroutine(getStats());
    }
    public void increaseInt()
    {
        charStats.intelligence++;
        charStats.skillPoints--;
        checkSP();
        dict.dictionary[id] = charStats;
        StartCoroutine(getStats());
    }
}
