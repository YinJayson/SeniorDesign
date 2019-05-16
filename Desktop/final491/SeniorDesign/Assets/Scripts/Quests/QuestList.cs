using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestList : MonoBehaviour {

    public List<Quests> quest = new List<Quests>();

    public void Awake() {
        //call the questlist 
        listOfQuests();
    }

    public Quests GetByName(string QuestName) {
        //Debug.Log("Test 7\n");
        for (int i = 0; i < quest.Count; i++) {
            //Debug.Log("Test 4\n");
            if (quest[i].QuestName == QuestName) {
                return quest[i];
            }
        }
        return null;
    }

    void listOfQuests() {
        quest = new List<Quests>()
        {
            //quest ID, title, description
            new Quests("Advice", "Get advice from the village elder", "Juice Box"),
            new Quests("Find the Archer", "Find the archer in your village and make her join your team", "Health Potion"),
           //new quests to be added after finlizong what scenes will be in the game
        };
    }
}
