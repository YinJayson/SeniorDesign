using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestList : MonoBehaviour {

    public List<Quests> quest = new List<Quests>();

    public void Awake() {
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
            new Quests(1, "Find the Archer", "Find the archer in your village and make her join your team"),
        };
    }
}
