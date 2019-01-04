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

            CharacterStats adrianStats = new CharacterStats("MonkMage", 6, 4, 2, 0, 0, 0);
            CharacterStats avisStats = new CharacterStats("Skeleton", 3, 6, 3, 0, 0, 0);
            CharacterStats luaStats = new CharacterStats("Mage", 1, 4, 7, 0, 0, 0);

            CharacterStats genericStats = new CharacterStats("Slime", 3, 3, 3, 5, 5);

            CharacterStats slimeStats = new CharacterStats("Slime", 1, 8, 1, 5, 5);
            CharacterStats orcStats = new CharacterStats("Orc", 5, 2, 2, 7, 5);
            CharacterStats skeletonStats = new CharacterStats("Skeleton", 2, 5, 5, 6, 5);
            CharacterStats livingArmorStats = new CharacterStats("LivingArmor", 8, 2, 0, 8, 5);
            CharacterStats goblinStats = new CharacterStats("Goblin", 5, 5, 2, 5, 5);

            dictionary.Add("adrian", adrianStats);
            dictionary.Add("avis", avisStats);
            dictionary.Add("lua", luaStats);
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
        CharacterStats temp = dictionary[id];
        return temp;
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
