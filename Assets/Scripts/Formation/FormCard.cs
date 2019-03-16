using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FormCard : MonoBehaviour
{
    public string id;
    public int pos;

    public FormManager form;

	void Start()
    {
        form = GameObject.FindObjectOfType<FormManager>();

        id = form.pos[pos];
        gameObject.transform.GetChild(1).GetComponent<Text>().text = char.ToUpper(id[0]) + id.Substring(1);
        gameObject.transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().sprite =
            Resources.Load<Sprite>("Sprites/Characters/" + GameObject.FindObjectOfType<CharacterDictionary>().getStats(id).spriteName) as Sprite;

        gameObject.transform.GetChild(3).transform.GetChild(1).GetComponent<Image>().fillAmount =
            GameObject.FindObjectOfType<HealthDictionary>().dictionary[id] / (float)(GameObject.FindObjectOfType<CharacterDictionary>().dictionary[id].strength * 2.5f);
        gameObject.transform.GetChild(3).transform.GetChild(2).GetComponent<Text>().text =
            GameObject.FindObjectOfType<HealthDictionary>().dictionary[id] + " / " + (int)(GameObject.FindObjectOfType<CharacterDictionary>().dictionary[id].strength * 2.5f);

        gameObject.transform.GetChild(4).transform.GetChild(1).GetComponent<Image>().fillAmount =
            (float)GameObject.FindObjectOfType<CharacterDictionary>().dictionary[id].exp / (float)GameObject.FindObjectOfType<CharacterDictionary>().dictionary[id].expToLevel;
        gameObject.transform.GetChild(4).transform.GetChild(2).GetComponent<Text>().text = 
             "<b>" + 
             GameObject.FindObjectOfType<CharacterDictionary>().dictionary[id].exp + " / " + GameObject.FindObjectOfType<CharacterDictionary>().dictionary[id].expToLevel
             + "</b>";
    }

    void Update()
    {
        // Health
        gameObject.transform.GetChild(3).transform.GetChild(1).GetComponent<Image>().fillAmount = (float)
            ((int)GameObject.FindObjectOfType<HealthDictionary>().dictionary[id] / (int)(GameObject.FindObjectOfType<CharacterDictionary>().getStats(id).strength * 2.5f));
        gameObject.transform.GetChild(3).transform.GetChild(2).GetComponent<Text>().text =
            GameObject.FindObjectOfType<HealthDictionary>().dictionary[id] + " / " + (int)(GameObject.FindObjectOfType<CharacterDictionary>().getStats(id).strength * 2.5f);
        
        // TODO: Update calculations when equipment is set up

        // EXP
        gameObject.transform.GetChild(4).transform.GetChild(1).GetComponent<Image>().fillAmount =
            (float)GameObject.FindObjectOfType<CharacterDictionary>().dictionary[id].exp / (float)GameObject.FindObjectOfType<CharacterDictionary>().getStats(id).expToLevel;
        gameObject.transform.GetChild(4).transform.GetChild(2).GetComponent<Text>().text =
             "<b>" +
             GameObject.FindObjectOfType<CharacterDictionary>().dictionary[id].exp + " / " + GameObject.FindObjectOfType<CharacterDictionary>().getStats(id).expToLevel
             + "</b>";
    }

    public void savePos()
    {
        FormManager form = GameObject.FindObjectOfType<FormManager>();
        form.pos[pos] = id;
    }
}
