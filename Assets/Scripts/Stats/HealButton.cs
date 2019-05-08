using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealButton : MonoBehaviour
{
    Button button;

    void Start()
    {
        button = GetComponent<Button>();

        button.onClick.AddListener(taskOnClick);
    }

    void taskOnClick()
    {
        FindObjectOfType<HealthDictionary>().healHero(1);
    }
}
