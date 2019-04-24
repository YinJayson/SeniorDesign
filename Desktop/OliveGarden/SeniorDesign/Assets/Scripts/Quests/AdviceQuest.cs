using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdviceQuest : MonoBehaviour
{
    public QuestList questList;

    public PlayersQuests playerQuests;

    public StartQuest startedQuests;

    Quests finishedQuest;

    public void endQuest(int ID) {

        playerQuests.QuestCompleted(ID);

    }


    public void endAdvice() {
        endQuest(1);
    }
}