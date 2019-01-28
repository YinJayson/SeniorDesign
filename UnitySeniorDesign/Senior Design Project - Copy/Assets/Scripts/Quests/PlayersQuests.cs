using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersQuests : MonoBehaviour {
    public List<Quests> playerQuests = new List<Quests>();
    public QuestList questList;

    public void QuestCompleted(int ID) {
        Quests completedQuest = questList.GetByID(ID);
        playerQuests.Add(completedQuest);
    }
}
