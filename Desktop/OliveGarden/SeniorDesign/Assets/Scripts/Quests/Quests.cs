using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quests : MonoBehaviour
{
    public int ID;
    public string QuestName;
    public string QuestDescription;
    //inventory item ID that is rewarded
    public int rewardID;
   

    public Quests(int ID, string QuestName, string QuestDescription, int rewardID)
    {
        this.ID = ID;
        this.QuestName = QuestName;
        this.QuestDescription = QuestDescription;
        this.rewardID = rewardID;
    }

}
