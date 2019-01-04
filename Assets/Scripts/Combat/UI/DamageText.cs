using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour
{
    //public GameObject target;
    GameObject target;

    Text targetText;
    float alpha;

    void Start()
    {
        target = gameObject.transform.parent.gameObject;
        targetText = gameObject.GetComponent<Text>();
        alpha = 1.0f;
    }

	void Update ()
    {
        /*
        if (target != null)
            gameObject.transform.position = new Vector2(target.transform.position.x, gameObject.transform.position.y + 0.2f);
        else
            Destroy(gameObject);
            */
        gameObject.transform.position = new Vector2(target.transform.position.x, gameObject.transform.position.y + 0.2f);

        targetText.color = new Color(0.825f, 0.05f, 0.05f, alpha);
        alpha -= Time.deltaTime / 1.5f;

        if (alpha <= 0)
            Destroy(gameObject);
	}
}
