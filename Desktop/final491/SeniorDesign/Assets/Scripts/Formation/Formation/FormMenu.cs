using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormMenu : MonoBehaviour
{
    void OnEnable()
    {
        resetCards();
    }

    public void resetCards()
    {
        BroadcastMessage("resetCard");
    }
}
