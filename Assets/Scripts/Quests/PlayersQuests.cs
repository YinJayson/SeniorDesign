using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersQuests : MonoBehaviour {
    public List<Quests> playerQuests = new List<Quests>();
    public QuestList questList;

    //data base with inventory and players current inventory database
    public List<InventoryItems> playerItems = new List<InventoryItems>();
    public ItemsList itemList;



    //one the player finished the quest
    public void QuestCompleted(int ID) {
        Quests completedQuest = questList.GetByID(ID);
        playerQuests.Add(completedQuest);
        RewardPlayer(ID);

        //after adding quest to finished players quest add prize (inventory item) inot players inventory
    }

    public void RewardPlayer(int ID) {
        //find inventory item that is being rewarded for that specific quest
        Quests reward = questList.GetByID(ID);
        InventoryItems rewardItem = itemList.GetByItemID(reward.rewardID);
        playerItems.Add(rewardItem);

    }

    public Quests GetByID(int ID) {
        for (int i = 0; i < playerQuests.Count; i++) {
            if (playerQuests[i].ID == ID) {
                return playerQuests[i];
            }
        }
        return null;
    }

    void Start()
    {
        /*
        //add quest here to see if everything gets added to the player quest list as well as player inventory
        QuestCompleted(1);
        for (int i = 0; i < playerQuests.Count; i++)
        {
            Debug.Log("Quests completed by player\n" + playerQuests[i].QuestName);
        }

        for (int i = 0; i < playerItems.Count; i++)
        {
            Debug.Log("Current Player Inventory\n" + playerItems[i].itemName);
        }
        */
    }

    /*public List<Quests> GetList(){
        return playerQuests;
    }
    */
}
/*
 Load in the inventory script to add the inventory item to the players onventoy
 load in the inventory to the quest list 
 then load in the inventory insances in this code
 add item into players inventory
    after finishing quest 


     */

    //maybe dont need to load in list to a list
    //just call in the inventory add itemm method separately to add item to players inventory

