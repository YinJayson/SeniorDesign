using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamScript : MonoBehaviour
{
    /*
    public GameObject char1;
    public GameObject char2;
    public GameObject char3;
    */

    public float x1, x2, x3;        // x1 is in front

    public TeamScript enemyTeam;

    public CharacterScript[] charPos;

    public bool victorious;
    public bool defeated;

    void Awake()
    {
        charPos = new CharacterScript[3];
        charPos[0] = gameObject.transform.GetChild(0).GetComponent<CharacterScript>();
        charPos[1] = gameObject.transform.GetChild(1).GetComponent<CharacterScript>();
        charPos[2] = gameObject.transform.GetChild(2).GetComponent<CharacterScript>();

        FormManager formation = GameObject.FindObjectOfType<FormManager>();
        charPos[0].id = formation.pos[0];
        charPos[1].id = formation.pos[1];
        charPos[2].id = formation.pos[2];
    }

    void Start()
    {


        /*
        charPos[0] = char1.GetComponent<CharacterScript>();
        charPos[1] = char2.GetComponent<CharacterScript>();
        charPos[2] = char3.GetComponent<CharacterScript>();

        charPos[0].targetPos = new Vector2(x1, 0);
        charPos[0].pos = 0;
        charPos[1].targetPos = new Vector2(x2, 0);
        charPos[1].pos = 1;
        charPos[2].targetPos = new Vector2(x3, 0);
        charPos[2].pos = 2;
        */


        charPos[0].targetPos = new Vector2(50, 0);
        charPos[0].pos = 0;
        charPos[1].targetPos = new Vector2(0, 0);
        charPos[1].pos = 1;
        charPos[2].targetPos = new Vector2(-50, 0);
        charPos[2].pos = 2;

        victorious = false;
        defeated = false;
    }

    void Update()
    {
        updatePos();

        if (charPos[0].ready && !victorious)
        {
            if (Input.GetKeyDown("w"))
                skill();
            else if (Input.GetKeyDown("d"))
                basicAttack();
            else if (Input.GetKeyDown("s"))
                swap();
            else if (Input.GetKeyDown("a"))
                block();
        }

        if (!charPos[0].alive && !defeated)
            if(!checkDefeat())
                moveToBack(0);
        if (!charPos[1].alive)
            if (charPos[2].alive)
                moveToBack(1);
    }

    public void moveToFront(int mover)
    {
        if (mover == 1)
        {
            if(charPos[2].alive)                // 3 2 1 F -> 1 3 2 F
            {
                CharacterScript temp1 = charPos[0];
                CharacterScript temp2 = charPos[2];

                charPos[0] = charPos[mover];
                charPos[1] = temp2;
                charPos[2] = temp1;
            }
            else                                     // x 2 1 F -> x 1 2 F
            {
                CharacterScript temp = charPos[0];

                charPos[0] = charPos[mover];
                charPos[1] = temp;
            }
                                                
        }
        else if (mover == 2)      // 3 2 1 F -> 1 2 3 F
        {
            CharacterScript temp = charPos[0];

            charPos[0] = charPos[mover];
            charPos[2] = temp;
        }
    }

    public void moveToMiddle(int mover)
    {
        if (!charPos[1].ready && mover == 2)           // 3 2 1 F -> 2 3 1 F
        {
            CharacterScript temp = charPos[1];

            charPos[1] = charPos[2];
            charPos[2] = temp;
        }
    }

    public void moveToBack(int mover)
    {
        if(mover == 0)
        {
            CharacterScript temp = charPos[0];

            charPos[0] = charPos[1];
            charPos[1] = charPos[2];
            charPos[2] = temp;
        }
        else if(mover == 1)
        {
            CharacterScript temp = charPos[1];

            charPos[1] = charPos[2];
            charPos[2] = temp;
        }
    }

    public void swap()
    {
        charPos[0].actionBar = 0.0f;

        if (charPos[2].alive)
        {
            charPos[2].actionBar += 20.0f;
            moveToFront(2);
        }
        else if (charPos[1].alive)
        {
            charPos[1].actionBar += 20.0f;
            moveToFront(1);
        }
        else
        {
            charPos[0].actionBar += 100.0f;
        }
    }

    public void updatePos()
    {
        if (!charPos[0].ready)
            if (charPos[1].ready)
                moveToFront(1);
            else if (charPos[2].ready)
                moveToFront(2);

        if (charPos[0].ready && !charPos[1].ready)
            if (charPos[2].ready)
                moveToMiddle(2);

        charPos[0].targetPos = new Vector2(x1, 0);
        charPos[0].pos = 0;
        charPos[1].targetPos = new Vector2(x2, 0);
        charPos[1].pos = 1;
        charPos[2].targetPos = new Vector2(x3, 0);
        charPos[2].pos = 2;
    }

    public void basicAttack()
    {
        charPos[0].actionBar = 0.0f;
        /*
        if (charPos[0].calculateCrit())
            enemyTeam.applyCritDamage(charPos[0].attack + (charPos[0].attack * charPos[0].critDamage), charPos[0].basicAttackType, 0);
        else
            enemyTeam.applyDamage(charPos[0].attack, charPos[0].basicAttackType, 0);
        */
        if (charPos[0].basicAttackType == true)
        {
            GameObject hit = Instantiate(Resources.Load<GameObject>("Prefabs/PhysicalAttack"), enemyTeam.charPos[0].transform);
            hit.GetComponent<ApplyDamage>().dmg = charPos[0].attack;
            hit.GetComponent<ApplyDamage>().critRate = charPos[0].critRate;
            hit.GetComponent<ApplyDamage>().critDmg = charPos[0].critDamage;
            hit.GetComponent<ApplyDamage>().physical = charPos[0].basicAttackType;
        }
        else
        {
            GameObject hit = Instantiate(Resources.Load<GameObject>("Prefabs/MagicAttack"), enemyTeam.charPos[0].transform);
            hit.GetComponent<ApplyDamage>().dmg = charPos[0].attack;
            hit.GetComponent<ApplyDamage>().critRate = charPos[0].critRate;
            hit.GetComponent<ApplyDamage>().critDmg = charPos[0].critDamage;
            hit.GetComponent<ApplyDamage>().physical = charPos[0].basicAttackType;
        }

        //Instantiate(Resources.Load<GameObject>("Prefabs/Hit"), new Vector2(enemyTeam.charPos[0].transform.position.x, enemyTeam.charPos[0].transform.position.y), Quaternion.identity, enemyTeam.charPos[0].transform);
        //Instantiate(Resources.Load<GameObject>("Prefabs/AttackPhysical"), new Vector2(enemyTeam.charPos[0].transform.position.x - 15, enemyTeam.charPos[0].transform.position.y), Quaternion.identity, enemyTeam.charPos[0].transform);
    }

    /*
    public void applyDamage(float damage, bool physical, int pos)
    {
        charPos[pos].applyDamage(damage, physical);

        if (!charPos[pos].alive)
            if(!checkDefeat())
                moveToBack(pos);
    }

    public void applyCritDamage(float damage, bool physical, int pos)
    {
        charPos[pos].applyCritDamage(damage, physical);

        if (!charPos[pos].alive)
            if (!checkDefeat())
                moveToBack(pos);
    }
    */

    public void skill()
    {
        if (charPos[0].GetComponent<Skill>().getReady())
        {
            charPos[0].actionBar = 0.0f;
            charPos[0].GetComponent<Skill>().skill();
        }
    }

    public void block()
    {
        charPos[0].actionBar = 0.0f;
        enemyTeam.charPos[0].actionBar -= 20.0f;
        enemyTeam.charPos[0].gameObject.AddComponent<BlockedDebuff>();
    }

    bool checkDefeat()
    {
        if (!charPos[0].alive && !charPos[1].alive && !charPos[2].alive)
        {
            setDefeat();
            return true;
        }
        else
            return false;
    }

    void setDefeat()
    {
        /*
        defeated = true;
        enemyTeam.victorious = true;
        GameObject defeatMenu = Instantiate(Resources.Load("Menus/VictoryMenu"), GameObject.FindGameObjectWithTag("CombatCanvas").transform) as GameObject;
        GameObject.FindGameObjectWithTag("ActionMenu").SetActive(false);

        CharacterScript[] chars = GameObject.FindObjectsOfType<CharacterScript>();
        for (int i = 0; i < chars.Length; i++)
            chars[i].stopActionBar();

        ActionBarScript[] actionBars = GameObject.FindObjectsOfType<ActionBarScript>();
        for (int i = 0; i < actionBars.Length; i++)
            actionBars[i].gameObject.SetActive(false);

        char1.SetActive(false);
        char2.SetActive(false);
        char3.SetActive(false);
        */
    }
}
