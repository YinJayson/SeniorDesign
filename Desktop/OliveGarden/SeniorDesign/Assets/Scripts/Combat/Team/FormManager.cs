using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormManager : MonoBehaviour
{
    private static bool created = false;

    public string[] pos;

    void Awake()
    {
        if(!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;

            pos = new string[3];
            pos[0] = "hero1";
            pos[1] = "hero2";
            pos[2] = "hero3";
        }
    }
}
