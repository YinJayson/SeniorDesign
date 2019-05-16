using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quests : MonoBehaviour
{
    //public int ID;
    public string QuestName;
    public string QuestDescription;
    //inventory item ID that is rewarded
    public string rewardItems;
   

    public Quests(string QuestName, string QuestDescription, string rewardItems)
    {
        //this.ID = ID;
        this.QuestName = QuestName;
        this.QuestDescription = QuestDescription;
        this.rewardItems = rewardItems;
    }

}
