using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectMenuScript : MonoBehaviour
{
    public EffectIcon icon;

    private void Update()
    {
        gameObject.transform.position = new Vector2(icon.transform.position.x, icon.transform.position.y + 15);
        gameObject.transform.GetChild(1).GetComponent<Text>().text = icon.target.getDuration().ToString("F2") + " s";
    }

    public void hideMenu()
    {
        Destroy(gameObject);
        //gameObject.SetActive(false);
    }
}
