using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartQuest : MonoBehaviour {
    public QuestList questList;

    public PlayersQuests playerQuests;

    public List<Quests> startedQuests = new List<Quests>();

    Quests checkedQuest;

    public void startQuest(int ID) {

        checkInProgress(ID);
        startedQuests.Add(checkedQuest);
        
    }
    //method to check if the quest is already in progress
    public Quests checkInProgress(int ID) {
        //find that the quest exists in the database
        //Quests 
        checkedQuest= questList.GetByID(ID);

        //check if quest is already in progress
        for (int i = 0; i < startedQuests.Count; i++)
        {
            if (startedQuests[i].ID != checkedQuest.ID)
            {
                return checkedQuest;
            }
            else{
                checkIfCompleted(ID);
            }
        }
        return null;

    }
    //check if the quest has already been completed and is currently in
    //the players completed quests database
    public Quests checkIfCompleted(int ID) {

        checkedQuest= questList.GetByID(ID);

        Quests completed = playerQuests.GetByID(checkedQuest.ID);

        if(completed.ID == checkedQuest.ID){
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
        startQuest(1);

        for (int i = 0; i < startedQuests.Count; i++)
        {
                Debug.Log("Quests now in progress\n" + startedQuests[i].QuestName);
        }   
    }
}
