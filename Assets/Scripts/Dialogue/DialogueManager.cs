using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Text convo;
    public List<string> conversation;
    
	// Use this for initialization
	void Start () {
        conversation = new List<string>();
	}

    public void LoadDialogue(Dialogue dialogue) {

        //go through each string in the array containing the dialogue
        foreach (string s in dialogue.sentences) {
            conversation.Add(s);
            convo.text = s;
            Debug.Log(s);
        }
    }

}
