using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipCard : MonoBehaviour
{
    public string id;

    public CharacterStats charStats;
    public CharacterDictionary dict;
    public EquippedItems equipment;
    public EquipmentList list;

    void Awake()
    {
        dict = GameObject.FindObjectOfType<CharacterDictionary>();
        charStats = dict.dictionary[id];
        equipment = GameObject.FindObjectOfType<EquipDictionary>().dictionary[id];
        list = GameObject.FindObjectOfType<EquipmentList>();
    }

    void Start()
    {
        gameObject.transform.Find("NameText").GetComponent<Text>().text = char.ToUpper(id[0]) + id.Substring(1);
    }

    public IEnumerator getStats()
    {
        yield return new WaitUntil(() => dict != null);
        /* Set character stats */
        gameObject.transform.Find("LevelText").GetComponent<Text>().text = "Level " + charStats.level;
        gameObject.transform.Find("StrengthText").GetComponent<Text>().text = "STR: " + charStats.strength;
        gameObject.transform.Find("DexText").GetComponent<Text>().text = "DEX: " + charStats.dex;
        gameObject.transform.Find("IntText").GetComponent<Text>().text = "INT: " + charStats.intelligence;

        /* Set attack and attack type */
        if (list.GetByName(equipment.equipped[3]).getAtkType())
            gameObject.transform.Find("AtkTypeText").GetComponent<Text>().text = "Atk Type: <b>Physical</b>";
        else
            gameObject.transform.Find("AtkTypeText").GetComponent<Text>().text = "Atk Type: <b>Magical</b>";
        gameObject.transform.Find("AtkText").GetComponent<Text>().text = "Attack: " + list.GetByName(equipment.equipped[3]).getAtk();

        /* Set armor stats */
        gameObject.transform.Find("DefText").GetComponent<Text>().text = "Defense: " +
            (list.GetByName(equipment.equipped[0]).getDefense() + list.GetByName(equipment.equipped[1]).getDefense() +
            list.GetByName(equipment.equipped[2]).getDefense());
        gameObject.transform.Find("ResText").GetComponent<Text>().text = "Resist: " +
            (list.GetByName(equipment.equipped[0]).getResist() + list.GetByName(equipment.equipped[1]).getResist() +
            list.GetByName(equipment.equipped[2]).getResist());
    }
}
