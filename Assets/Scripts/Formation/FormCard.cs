using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FormCard : MonoBehaviour
{
    public string id;
    public int pos;
    public bool getIDByPos;

    Transform healthBar;
    Transform expBar;
    public FormManager form;

	void Start()
    {
        healthBar = gameObject.transform.Find("HealthBar");
        expBar = gameObject.transform.Find("EXPBar");
        form = GameObject.FindObjectOfType<FormManager>();

        if (getIDByPos)
        {
            id = form.pos[pos];
            switch (pos)
            {
                case 0:
                    gameObject.transform.Find("PosText").GetComponent<Text>().text = "Frontline";
                    break;
                case 1:
                    gameObject.transform.Find("PosText").GetComponent<Text>().text = "Midline";
                    break;
                case 2:
                    gameObject.transform.Find("PosText").GetComponent<Text>().text = "Backline";
                    break;
            }
        }

        gameObject.transform.Find("NameText").GetComponent<Text>().text = char.ToUpper(id[0]) + id.Substring(1);
        gameObject.transform.Find("Buttons").transform.Find("CharButton").GetComponent<Image>().sprite =
            Resources.Load<Sprite>("Sprites/Characters/" + GameObject.FindObjectOfType<CharacterDictionary>().getStats(id).spriteName) as Sprite;

        healthBar.transform.Find("HealthBarFilling").GetComponent<Image>().fillAmount =
            GameObject.FindObjectOfType<HealthDictionary>().dictionary[id] / (float)(GameObject.FindObjectOfType<CharacterDictionary>().dictionary[id].strength * 2.5f);
        healthBar.transform.Find("HealthBarText").GetComponent<Text>().text =
            GameObject.FindObjectOfType<HealthDictionary>().dictionary[id] + " / " + (int)(GameObject.FindObjectOfType<CharacterDictionary>().dictionary[id].strength * 2.5f);

        expBar.transform.Find("EXPBarFilling").GetComponent<Image>().fillAmount =
            (float)GameObject.FindObjectOfType<CharacterDictionary>().dictionary[id].exp / (float)GameObject.FindObjectOfType<CharacterDictionary>().dictionary[id].expToLevel;
        expBar.transform.GetChild(2).GetComponent<Text>().text = 
             "<b>" + 
             GameObject.FindObjectOfType<CharacterDictionary>().dictionary[id].exp + " / " + GameObject.FindObjectOfType<CharacterDictionary>().dictionary[id].expToLevel
             + "</b>";
    }

    void Update()
    {
        // Health
        healthBar.transform.Find("HealthBarFilling").GetComponent<Image>().fillAmount =
            GameObject.FindObjectOfType<HealthDictionary>().dictionary[id] / (float)(GameObject.FindObjectOfType<CharacterDictionary>().dictionary[id].strength * 2.5f);
        healthBar.transform.Find("HealthBarText").GetComponent<Text>().text =
            GameObject.FindObjectOfType<HealthDictionary>().dictionary[id] + " / " + (int)(GameObject.FindObjectOfType<CharacterDictionary>().dictionary[id].strength * 2.5f);

        // TODO: Update calculations when equipment is set up

        // EXP
        expBar.transform.Find("EXPBarFilling").GetComponent<Image>().fillAmount =
            (float)GameObject.FindObjectOfType<CharacterDictionary>().dictionary[id].exp / (float)GameObject.FindObjectOfType<CharacterDictionary>().dictionary[id].expToLevel;
        expBar.transform.GetChild(2).GetComponent<Text>().text =
             "<b>" +
             GameObject.FindObjectOfType<CharacterDictionary>().dictionary[id].exp + " / " + GameObject.FindObjectOfType<CharacterDictionary>().dictionary[id].expToLevel
             + "</b>";
    }

    public void savePos()
    {
        FormManager form = GameObject.FindObjectOfType<FormManager>();
        form.pos[pos] = id;
    }

    public void resetCard()
    {
        Start();
    }
}
