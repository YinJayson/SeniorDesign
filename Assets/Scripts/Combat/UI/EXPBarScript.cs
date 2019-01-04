using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EXPBarScript : MonoBehaviour
{
    public CharacterDictionary dict;
    public string targetName;
    public int exp;
    public int expToLevel;

    void Start()
    {
        CharacterScript target = GameObject.Find(targetName).GetComponent<CharacterScript>();

        dict = FindObjectOfType<CharacterDictionary>();
        exp = dict.dictionary[target.id].exp;
        expToLevel = dict.dictionary[target.id].expToLevel;

        gameObject.transform.GetChild(0).GetComponent<Image>().fillAmount = (float)exp / (float)expToLevel;
    }

    /*
    IEnumerator wait()
    {
        Debug.Log(Time.time);
        yield return new WaitForSeconds(10);
        Debug.Log(Time.time);
    }
    */
}
