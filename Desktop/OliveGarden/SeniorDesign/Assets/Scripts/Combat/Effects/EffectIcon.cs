using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectIcon : MonoBehaviour
{
    public string effect;
    public string sprite;
    public Effect target;
    //public float duration;
    //public float maxDuration;

    static GameObject effectMenu;
    Button button;

    void Start()
    {
        button = gameObject.GetComponent<Button>();
        /*
        effectMenu = GameObject.FindGameObjectWithTag("EffectMenu");
        
        if (effectMenu == null)
            effectMenu = Instantiate(Resources.Load("Menus/EffectMenu") as GameObject, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 15), Quaternion.identity, GameObject.FindGameObjectWithTag("CombatCanvas").transform);
            */
        button.onClick.AddListener(showEffectMenu);
        gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/" + sprite) as Sprite;
    }

    void Update()
    {
        if (target != null)
            gameObject.GetComponent<Image>().fillAmount = target.getDuration() / target.getMaxDuration();
    }

    void showEffectMenu()
    {
        if(effectMenu == null)
            effectMenu = Instantiate(Resources.Load("Menus/EffectMenu") as GameObject, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 15), Quaternion.identity, GameObject.FindGameObjectWithTag("CombatCanvas").transform);
        /*
        if (GameObject.FindGameObjectWithTag("EffectMenu") != null)
            effectMenu = GameObject.FindGameObjectWithTag("EffectMenu");
        else
            effectMenu = Instantiate(Resources.Load("Menus/EffectMenu") as GameObject, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 15), Quaternion.identity, GameObject.FindGameObjectWithTag("CombatCanvas").transform);
        */
        effectMenu.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 15);
        effectMenu.SetActive(true);
        effectMenu.GetComponent<EffectMenuScript>().icon = this;
        effectMenu.transform.Find("EffectText").GetComponent<Text>().text = effect;
	}

    public void expire()
    {
        if (effectMenu != null && effectMenu.GetComponent<EffectMenuScript>().icon == this)
            Destroy(effectMenu);

        Destroy(gameObject);
    }
}
