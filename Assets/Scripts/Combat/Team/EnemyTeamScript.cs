using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTeamScript : TeamScript
{
    //public GameObject char1;
    //public GameObject char2;
    //public GameObject char3;

    //public TeamScript enemyTeam;

    //public CharacterScript[] charPos;

    //public float x1, x2, x3;        // x1 is in front
    public float delay;

    public bool takingAction;

    public int expValue;
    public int goldValue;

    CharacterDictionary dict;

    void Awake()
    {
        charPos = new CharacterScript[3];

        charPos[0] = gameObject.transform.GetChild(0).GetComponent<CharacterScript>();
        charPos[1] = gameObject.transform.GetChild(1).GetComponent<CharacterScript>();
        charPos[2] = gameObject.transform.GetChild(2).GetComponent<CharacterScript>();

        charPos[0].targetPos = new Vector2(-50, 0);
        charPos[0].pos = 0;
        charPos[1].targetPos = new Vector2(0, 0);
        charPos[1].pos = 1;
        charPos[2].targetPos = new Vector2(50, 0);
        charPos[2].pos = 2;

        takingAction = false;
        defeated = false;
        victorious = false;

        //dict = GameObject.FindObjectOfType<CharacterDictionary>();

        for (int i = 0; i < charPos.Length; i++)
        {
            string idName;
            switch(Mathf.RoundToInt(Random.Range(0.0f, 4.0f)))
            {
                case 0:
                    idName = "slime";
                    break;
                case 1:
                    idName = "orc";
                    break;
                case 2:
                    idName = "skeleton";
                    break;
                case 3:
                    idName = "livingArmor";
                    break;
                case 4:
                    idName = "goblin";
                    break;
                default:
                    idName = "generic";
                    break;
            }

            charPos[i].id = idName;

            goldValue += charPos[i].goldValue;
            expValue += charPos[i].expValue;
        }
    }

    void Update()
    {
        updatePos();

        if (charPos[0].ready && charPos[0].inPosition && !takingAction && !victorious)
        {
            enemyAI();
        }

        if (!charPos[0].alive && !defeated)
            if(!checkDefeat())
                moveToBack(0);
        if (!charPos[1].alive && charPos[2].alive)
            if (!checkDefeat())
                moveToBack(1);
    }

    void enemyAI()
    {
        StartCoroutine(basicAttack());
    }
    /*
    public void moveToFront(int mover)
    {
        if (mover == 1)
        {
            if (charPos[2].getAlive())                // 3 2 1 F -> 1 3 2 F
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
        if (!charPos[1].getReady() && mover == 2)           // 3 2 1 F -> 2 3 1 F
        {
            CharacterScript temp = charPos[1];

            charPos[1] = charPos[2];
            charPos[2] = temp;
        }
    }

    public void moveToBack(int mover)
    {
        if (mover == 0)
        {
            CharacterScript temp = charPos[0];

            charPos[0] = charPos[1];
            charPos[1] = charPos[2];
            charPos[2] = temp;
        }
        else if (mover == 1)
        {
            CharacterScript temp = charPos[1];

            charPos[1] = charPos[2];
            charPos[2] = temp;
        }
    }
    */
    /*
    public void swap()
    {
        if (charPos[2].getAlive())
        {
            charPos[2].actionBar += 20.0f;
            moveToFront(2);
        }
        else if (charPos[1].getAlive())
        {
            charPos[1].actionBar += 20.0f;
            moveToFront(1);
        }
        else
        {
            charPos[0].actionBar += 100.0f;
        }
    }
    */
    /*
    public void updatePos()
    {
        if (!charPos[0].getReady())
            if (charPos[1].getReady())
                moveToFront(1);
            else if (charPos[2].getReady())
                moveToFront(2);

        if (charPos[0].getReady() && !charPos[1].getReady())
            if (charPos[2].getReady())
                moveToMiddle(2);

        charPos[0].targetPos = new Vector2(x1, 0);
        charPos[0].pos = 0;
        charPos[1].targetPos = new Vector2(x2, 0);
        charPos[1].pos = 1;
        charPos[2].targetPos = new Vector2(x3, 0);
        charPos[2].pos = 2;
    }
    */

    new public IEnumerator basicAttack()
    {
        CharacterScript attacker = charPos[0].GetComponent<CharacterScript>();

        takingAction = true;

        yield return new WaitForSeconds(delay);

        if (attacker == charPos[0].GetComponent<CharacterScript>() && charPos[0].ready)
        {
            charPos[0].actionBar = 0.0f;

            if (charPos[0].basicAttackType == true)
            {
                GameObject hit = Instantiate(Resources.Load<GameObject>("Prefabs/PhysicalAttack"), enemyTeam.charPos[0].transform);
                hit.transform.localEulerAngles = new Vector3(0, 180, 0);
                hit.GetComponent<ApplyDamage>().dmg = charPos[0].attack;
                hit.GetComponent<ApplyDamage>().critRate = charPos[0].critRate;
                hit.GetComponent<ApplyDamage>().critDmg = charPos[0].critDamage;
                hit.GetComponent<ApplyDamage>().physical = charPos[0].basicAttackType;
            }
            else
            {
                GameObject hit = Instantiate(Resources.Load<GameObject>("Prefabs/MagicAttack"), enemyTeam.charPos[0].transform);
                hit.transform.localEulerAngles = new Vector3(0, 180, 0);
                hit.GetComponent<ApplyDamage>().dmg = charPos[0].attack;
                hit.GetComponent<ApplyDamage>().critRate = charPos[0].critRate;
                hit.GetComponent<ApplyDamage>().critDmg = charPos[0].critDamage;
                hit.GetComponent<ApplyDamage>().physical = charPos[0].basicAttackType;
            }
            //enemyTeam.applyDamage(charPos[0].attack, charPos[0].basicAttackType, 0);
        }

        takingAction = false;
    }
    /*
    public void applyDamage(int damage, bool physical, int pos)
    {
        charPos[pos].applyDamage(damage, physical);

        if (!charPos[pos].getAlive())
            if (!checkDefeat())
                moveToBack(pos);
    }
    */

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
        defeated = true;
        enemyTeam.victorious = true;

        GameObject victoryMenu = Instantiate(Resources.Load("Menus/VictoryMenu"), GameObject.FindGameObjectWithTag("CombatCanvas").transform) as GameObject;
        victoryMenu.GetComponent<VictoryMenuScript>().setGoldGained(goldValue);
        victoryMenu.GetComponent<VictoryMenuScript>().setEXPGained(expValue);

        GameObject.FindGameObjectWithTag("ActionMenu").SetActive(false);

        CharacterDictionary dict = GameObject.FindObjectOfType<CharacterDictionary>();
        HealthDictionary HPDict = GameObject.FindObjectOfType<HealthDictionary>();
        for (int i = 0; i < enemyTeam.charPos.Length; i++)
        {
            CharacterStats charStats = dict.dictionary[enemyTeam.charPos[i].id];
            charStats.addEXP(expValue);
            dict.dictionary[enemyTeam.charPos[i].id] = charStats;

            HPDict.dictionary[enemyTeam.charPos[i].id] = enemyTeam.charPos[i].HP;

            //Debug.Log("EXP for " + enemyTeam.charPos[i].id + ": " + dict.dictionary[enemyTeam.charPos[i].id].exp);
            //Debug.Log("Level for " + enemyTeam.charPos[i].id + ": " + dict.dictionary[enemyTeam.charPos[i].id].level);
        }

        CharacterScript[] chars = GameObject.FindObjectsOfType<CharacterScript>();
        for(int i = 0; i < chars.Length; i++)
            chars[i].stopActionBar();

        ActionBarScript[] actionBars = GameObject.FindObjectsOfType<ActionBarScript>();
        for (int i = 0; i < actionBars.Length; i++)
            actionBars[i].gameObject.SetActive(false);

        Destroy(gameObject);
        /*
        charPos[0].gameObject.SetActive(false);
        charPos[1].gameObject.SetActive(false);
        charPos[2].gameObject.SetActive(false);
        */
    }
}
