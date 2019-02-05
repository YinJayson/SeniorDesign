using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormChanger : MonoBehaviour
{
    public int targetPos;
    public string id;

    FormManager formation;

    void Start()
    {
        formation = GameObject.FindObjectOfType<FormManager>();
    }

    public void changePos()
    {
        // Check for swap
        switch (targetPos)
        {
            case 0:
                if (string.Equals(id, formation.pos[1]))
                    swapPos(targetPos, 1);
                else if (string.Equals(id, formation.pos[2]))
                    swapPos(targetPos, 2);
                break;
            case 1:
                if (string.Equals(id, formation.pos[0]))
                    swapPos(targetPos, 0);
                else if (string.Equals(id, formation.pos[2]))
                    swapPos(targetPos, 2);
                break;
            case 2:
                if (string.Equals(id, formation.pos[0]))
                    swapPos(targetPos, 0);
                else if (string.Equals(id, formation.pos[1]))
                    swapPos(targetPos, 1);
                break;
        }

        // If swap didn't occur
        if(!string.Equals(id, formation.pos[targetPos]))
            formation.pos[targetPos] = id;
    }

    public void swapPos(int target, int original)
    {
        string temp = formation.pos[target];
        formation.pos[target] = formation.pos[original];
        formation.pos[original] = temp;
    }

    public void setTargetPos(int pos)
    {
        targetPos = pos;
        gameObject.transform.Find("TargetPos").GetComponent<FormCard>().pos = targetPos;
        gameObject.transform.Find("TargetPos").GetComponent<FormCard>().resetCard();
    }

    public void changeTo(string id)
    {
        this.id = id;
        changePos();
    }
}
