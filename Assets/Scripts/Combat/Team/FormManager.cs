using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormManager : MonoBehaviour
{
    public string[] pos;

    private static bool created = false;

    void Awake()
    {
        if(!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;

            pos = new string[3];
            pos[0] = "adrian";
            pos[1] = "avis";
            pos[2] = "lua";
        }
    }
}
