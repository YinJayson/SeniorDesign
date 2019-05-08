using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCardButton : MonoBehaviour
{
    string id;

    void Update()
    {
        id = gameObject.transform.parent.GetComponent<FormCard>().id;    // id is assigned in Update incase characters are changed
        resetSkillCard();
    }

    public void initMenu()
    {
        Instantiate(Resources.Load("Menus/SkillMenu" + id), gameObject.transform.parent.parent);
    }

    // Assigns skill button's color and image
    public void resetSkillCard()
    {
        switch (GameObject.FindObjectOfType<SkillDictionary>().dictionary[id])
        {
            case 1:
                gameObject.transform.Find("Background").GetComponent<Image>().color = new Color(1.0f, 0.05882353f, 0.0f);
                gameObject.transform.Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/PhysicalAttack") as Sprite;
                break;
            case 2:
                gameObject.transform.Find("Background").GetComponent<Image>().color = new Color(0.0f, 1.0f, 0.7544947f);
                gameObject.transform.Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Guard") as Sprite;
                break;
            case 3:
                gameObject.transform.Find("Background").GetComponent<Image>().color = new Color(0.0543459f, 0.735849f, 0.0f);
                gameObject.transform.Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/SkillImage") as Sprite;
                break;
        }
    }
}
