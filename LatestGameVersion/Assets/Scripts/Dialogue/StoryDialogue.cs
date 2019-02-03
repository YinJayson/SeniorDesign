using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryDialogue : MonoBehaviour {

    public Dialogue dialogue;

    public void Talk()
    {
        FindObjectOfType<DialogueManager>().LoadDialogue(dialogue);
    }

}
