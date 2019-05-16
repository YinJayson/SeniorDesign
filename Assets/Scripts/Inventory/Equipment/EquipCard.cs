using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipCard : MonoBehaviour
{
    public string id;

    public CharacterStats charStats;
    public CharacterDictionary charDict;
    public EquippedItems equipped;
    public EquipmentDictionary equipmentDict;
    //public EquipmentList list;

    void Awake()
    {
        charDict = GameObject.FindObjectOfType<CharacterDictionary>();
        charStats = charDict.dictionary[id];
        equipped = GameObject.FindObjectOfType<EquipDictionary>().dictionary[id];
        equipmentDict = GameObject.FindObjectOfType<EquipmentDictionary>();
    }

    void Start()
    {
        gameObject.transform.Find("NameText").GetComponent<Text>().text = char.ToUpper(id[0]) + id.Substring(1);
    }

    public void startGetStats()
    {
        StartCoroutine(getStats());
    }
    public IEnumerator getStats()
    {
        yield return new WaitUntil(() => charDict != null);
        /* Set character stats */
        gameObject.transform.Find("LevelText").GetComponent<Text>().text = "Level " + charStats.level;
        gameObject.transform.Find("StrengthText").GetComponent<Text>().text = "STR: " + charStats.strength;
        gameObject.transform.Find("DexText").GetComponent<Text>().text = "DEX: " + charStats.dex;
        gameObject.transform.Find("IntText").GetComponent<Text>().text = "INT: " + charStats.intelligence;

        /* Set attack and attack type */
        if (equipmentDict.weaponDictionary[equipped.weapon].getAtkType())//GetByName(equipment.equipped[3]).getAtkType())
            gameObject.transform.Find("AtkTypeText").GetComponent<Text>().text = "Atk Type: <b>Physical</b>";
        else
            gameObject.transform.Find("AtkTypeText").GetComponent<Text>().text = "Atk Type: <b>Magical</b>";
        gameObject.transform.Find("AtkText").GetComponent<Text>().text = "Attack: " + ((0.75 * (charStats.strength + charStats.dex + charStats.intelligence)) + equipmentDict.weaponDictionary[equipped.weapon].getAttack());//list.GetByName(equipment.equipped[3]).getAtk();

        /* Set armor stats */

        gameObject.transform.Find("DefText").GetComponent<Text>().text = "Defense: " + 
            (equipmentDict.armorDictionary[equipped.helm].getDefense() + equipmentDict.armorDictionary[equipped.armor].getDefense() + 
            equipmentDict.armorDictionary[equipped.pants].getDefense());
        /*
        (list.GetByName(equipment.equipped[0]).getDefense() + list.GetByName(equipment.equipped[1]).getDefense() +
        list.GetByName(equipment.equipped[2]).getDefense());
        */
        gameObject.transform.Find("ResText").GetComponent<Text>().text = "Resist: " +
            (equipmentDict.armorDictionary[equipped.helm].getResist() + equipmentDict.armorDictionary[equipped.armor].getResist() +
            equipmentDict.armorDictionary[equipped.pants].getResist());
            /*
            (list.GetByName(equipment.equipped[0]).getResist() + list.GetByName(equipment.equipped[1]).getResist() +
            list.GetByName(equipment.equipped[2]).getResist());
            */
        
    }
}
