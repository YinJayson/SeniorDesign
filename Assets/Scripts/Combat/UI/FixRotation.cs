using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixRotation : MonoBehaviour
{
    // Used for fixing damage text to face the right direction
	void Start ()
    {
        //gameObject.transform.eulerAngles = new Vector3(0, gameObject.transform.parent.eulerAngles.y, 0);
        Debug.Log(gameObject.transform.parent.eulerAngles.y);
	}
}
