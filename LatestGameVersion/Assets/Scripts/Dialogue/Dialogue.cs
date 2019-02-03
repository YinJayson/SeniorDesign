
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]//can now modify in the inspector
public class Dialogue{
    [TextArea(1,20)]
    public string[] sentences;
}
