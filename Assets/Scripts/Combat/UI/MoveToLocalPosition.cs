using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToLocalPosition : MonoBehaviour
{
    public float x;
    public float y;
    public float timeToTarget;
    public float delay;

    bool delayFinished;

    Vector2 startPos;
    Vector2 endPos;
    float progress;

    void Start()
    {
        startPos = gameObject.transform.localPosition;
        delayFinished = false;
        progress = 0.0f;

        StartCoroutine(startDelay());
    }

    void Update()
    {
        if (delayFinished)
        {
            endPos = new Vector2(x, y);
            progress += Time.deltaTime / timeToTarget;
            transform.localPosition = Vector2.Lerp(startPos, endPos, progress);
        }
    }

    IEnumerator startDelay()
    {
        yield return new WaitForSeconds(delay);
        delayFinished = true;
    }
}
