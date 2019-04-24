using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncounterScript : MonoBehaviour
{
    public float distanceUntilEncounter;
    public Vector2 position;

    void Start()
    {
        distanceUntilEncounter = Random.Range(0.5f, 1.0f) * 50.0f;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter");
        position = transform.position;
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("In zone");

        distanceUntilEncounter -= Vector2.Distance(transform.position, position);
        position = transform.position;

        if (distanceUntilEncounter <= 0.0f)
            encounter();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit");
    }

    void encounter()
    {
        Debug.Log("Encounter!");
        FindObjectOfType<PositionLoader>().position = transform.position;
        FindObjectOfType<LoadScene>().loadScene("CombatScene");
        Start();
    }
}
