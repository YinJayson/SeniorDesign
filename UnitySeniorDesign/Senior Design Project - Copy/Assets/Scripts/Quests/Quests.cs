using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quests : MonoBehaviour
{
    public int ID;
    public string QuestName;
    public string QuestDescription;
    

    public Quests(int ID, string QuestName, string QuestDescription)
    {
        this.ID = ID;
        this.QuestName = QuestName;
        this.QuestDescription = QuestDescription;
    }

}