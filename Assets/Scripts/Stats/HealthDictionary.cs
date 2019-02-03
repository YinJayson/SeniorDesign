using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDictionary : MonoBehaviour
{
    public Dictionary<string, int> dictionary;

    private static bool created = false;

    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);

            dictionary = new Dictionary<string, int>();
        }
    }

    void Start()
    {
        if (!created)
        {
            dictionary.Add("adrian", (int)(GameObject.FindObjectOfType<CharacterDictionary>().getStats("adrian").strength * 2.5f));
            dictionary.Add("lua", (int)(GameObject.FindObjectOfType<CharacterDictionary>().getStats("lua").strength * 2.5f));
            dictionary.Add("avis", (int)(GameObject.FindObjectOfType<CharacterDictionary>().getStats("avis").strength * 2.5f));

            created = true;
        }
        // TODO: Update calculations when equipment is set up
    }

    public int getHealth(string id)
    {
        return dictionary[id];
    }
}
