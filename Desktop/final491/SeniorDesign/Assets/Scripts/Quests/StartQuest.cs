using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartQuest : MonoBehaviour {
    public QuestList questList;

    public PlayersQuests playerQuests;

    public List<Quests> startedQuests = new List<Quests>();

    Quests checkedQuest;

    public void startQuest(string QuestName) {

        checkInProgress(QuestName);
        startedQuests.Add(checkedQuest);
        
    }
    //method to check if the quest is already in progress
    public Quests checkInProgress(string QuestName) {
        //find that the quest exists in the database
        //Quests 
        checkedQuest= questList.GetByName(QuestName);

        //check if quest is already in progress
        for (int i = 0; i < startedQuests.Count; i++)
        {
            if (startedQuests[i].QuestName != checkedQuest.QuestName)
            {
                return checkedQuest;
            }
            else{
                checkIfCompleted(QuestName);
            }
        }
        return null;

    }
    //check if the quest has already been completed and is currently in
    //the players completed quests database
    public Quests checkIfCompleted(string QuestName) {

        checkedQuest= questList.GetByName(QuestName);

        Quests completed = playerQuests.GetByName(checkedQuest.QuestName);

        if(completed.QuestName == checkedQuest.QuestName){
            return null;
        }

        return null;
    }

    /*public Quests checkIfCompleted(int ID) {

        Quests checkedQuest= questList.GetByID(ID);



        for (int i = 0; i < playerQuests.Count; i++)
        {
            if (playerQuests[i].ID == checkedQuest.ID)
            {
                return null;
            }
        }
    }*/

    
    
    /*void start() {
        //Guy.onClick.AddListener(delegate { startQuest(1); });

        startQuest(1);
        for (int i = 0; i < startedQuests.Count; i++)
        {
            Debug.Log("Quests now in progress\n" + startedQuests[i].QuestName);
        }
    }*/

    public void giveQuest(){
        startQuest("Find the Archer");

        for (int i = 0; i < startedQuests.Count; i++)
        {
                Debug.Log("Quests now in progress\n" + startedQuests[i].QuestName);
        }   
    }
}
