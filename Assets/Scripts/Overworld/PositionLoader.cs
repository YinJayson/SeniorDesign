using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionLoader : MonoBehaviour
{
    public Vector2 position;
    bool created = false;

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            created = true;
        }
    }

}
