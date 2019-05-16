using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdviceQuest : MonoBehaviour
{
    public QuestList questList;

    public PlayersQuests playerQuests;

    public StartQuest startedQuests;

    Quests finishedQuest;

    public void endQuest(string QuestName) {
        //Debug.Log("Test 1\n");
        playerQuests.QuestCompleted(QuestName);
        Debug.Log("Advice Quest Completed!");

    }


    public void endAdvice() {
        endQuest("Find the Archer");
    }
}