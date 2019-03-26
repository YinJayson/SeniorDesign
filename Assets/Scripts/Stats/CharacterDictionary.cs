using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDictionary : MonoBehaviour
{
    public Dictionary<string, CharacterStats> dictionary;

    private static bool created = false;

    void Awake()
    {
        if(!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;

            dictionary = new Dictionary<string, CharacterStats>();

            CharacterStats hero1Stats = new CharacterStats("MonkMage", 6, 4, 2, true, 0, 0, 0);
            CharacterStats hero2Stats = new CharacterStats("ranger", 3, 6, 3, true, 0, 0, 0);
            CharacterStats hero3Stats = new CharacterStats("Mage", 1, 4, 7, false, 0, 0, 0);

            CharacterStats genericStats = new CharacterStats("Slime", 3, 3, 3, true, 5, 5);

            CharacterStats slimeStats = new CharacterStats("Slime", 1, 6, 1, true, 5, 5);
            CharacterStats orcStats = new CharacterStats("Orc", 5, 2, 2, true, 7, 5);
            CharacterStats skeletonStats = new CharacterStats("Skeleton", 2, 5, 5, false, 6, 5);
            CharacterStats livingArmorStats = new CharacterStats("LivingArmor", 8, 2, 0, true, 8, 5);
            CharacterStats goblinStats = new CharacterStats("Goblin", 5, 5, 2, true, 5, 5);

            dictionary.Add("hero1", hero1Stats);
            dictionary.Add("hero2", hero2Stats);
            dictionary.Add("hero3", hero3Stats);
            dictionary.Add("generic", genericStats);
            dictionary.Add("slime", slimeStats);
            dictionary.Add("orc", orcStats);
            dictionary.Add("skeleton", skeletonStats);
            dictionary.Add("livingArmor", livingArmorStats);
            dictionary.Add("goblin", goblinStats);
        }
    }

    public CharacterStats getStats(string id)
    {
        return dictionary[id];
    }

    /*
    public void updateStats(StatCard statCard)//(string id, int strength, int dex, int intelligence)
    {
        //CharacterStats temp = new CharacterStats(dictionary[id].spriteName, strength, dex, intelligence, 0, 0);
        //dictionary.Add(id, temp);
        CharacterStats updatedStats = new CharacterStats(dictionary[statCard.id].spriteName, statCard.tempStrength, statCard.tempDex, statCard.tempInt, statCard.);
        dictionary[statCard.id] = updatedStats;
        Debug.Log("Updating stats");
    }
    */
}
