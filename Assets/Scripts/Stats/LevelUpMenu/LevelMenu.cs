﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenu : MonoBehaviour
{
    void OnEnable()
    {
        BroadcastMessage("getStats");
    }
}
