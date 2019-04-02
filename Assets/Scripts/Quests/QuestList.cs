using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestList : MonoBehaviour {

    public List<Quests> quest = new List<Quests>();

    public void Awake() {
        //call the questlist 
        listOfQuests();
    }

    public Quests GetByID(int ID) {
        for (int i = 0; i < quest.Count; i++) {
            if (quest[i].ID == ID) {
                return quest[i];
            }
        }
        return null;
    }

    void listOfQuests() {
        quest = new List<Quests>()
        {
            //quest ID, title, description
            new Quests(1, "Advice", "Get advice from the village elder", 4),
            new Quests(2, "Find the Archer", "Find the archer in your village and make her join your team", 1),
           //new quests to be added after finlizong what scenes will be in the game
        };
    }
}
