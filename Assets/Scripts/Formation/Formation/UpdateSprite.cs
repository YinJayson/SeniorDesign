using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSprite : MonoBehaviour
{
	void Update ()
    {
        gameObject.GetComponent<Image>().sprite =
            Resources.Load<Sprite>("Sprites/Characters/" + GameObject.FindObjectOfType<CharacterDictionary>().getStats(gameObject.transform.parent.parent.GetComponent<FormCard>().id).spriteName) as Sprite;
    }
}
