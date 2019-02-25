using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterScript : MonoBehaviour
{
    public int pos;
    public string id;

    public Vector2 targetPos;

    public int baseStrength;
    public int baseDex;
    public int baseIntelligence;
    public int baseMaxHP;
    public int strength;
    public int dex;
    public int intelligence;
    public int defense;
    public int resist;
    public int maxHP;
    public int HP;
    public int attack;
    public int baseAttack;
    public int wpnAttack = 0;
    public int speed;
    public bool basicAttackType;
    public float damageMulti;
    public float critRate;
    public float critDamage;

    // Change these values to balance stats
    public const float dmgStr = 1.25f;
    public const float dmgDex = 0.75f;
    public const float hpStr = 2.5f;
    public const float spdDex = 2.5f;
    public const float critDex = 0.0175f;

    public float actionBar;

    public int goldValue;
    public int expValue;

    public bool alive;
    public bool ready;
    public bool inPosition;

    //public GameObject effectBar;
    //public GameObject team;
    //public Transform combatCanvas;
    public CharacterStats charStats;

    bool progressActionBar;

    void Start ()
    {
        if (id != null)
        {
            charStats = GameObject.FindObjectOfType<CharacterDictionary>().getStats(id);
            initSkill();
        }
        else
            charStats = GameObject.FindObjectOfType<CharacterDictionary>().getStats("generic");

        gameObject.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Characters/" + charStats.spriteName) as Sprite;
        //Debug.Log("Sprites/Characters/" + charStats.spriteName);

        baseStrength = charStats.strength;
        baseDex = charStats.dex;
        baseIntelligence = charStats.intelligence;
        goldValue = charStats.goldValue;
        expValue = charStats.expValue;

        strength = baseStrength;
        dex = baseDex;
        intelligence = baseIntelligence;

        alive = true;
        ready = false;
        inPosition = true;

        baseAttack = (int)(baseStrength * dmgStr + baseDex * dmgDex);
        attack = baseAttack + wpnAttack;

        baseMaxHP = (int)(baseStrength * hpStr);
        maxHP = baseMaxHP;
        if (GameObject.FindObjectOfType<HealthDictionary>().dictionary.ContainsKey(id))
            HP = GameObject.FindObjectOfType<HealthDictionary>().getHealth(id);
        else
            HP = maxHP;

        speed = (int)(baseDex * spdDex);
        critRate = baseDex * critDex;
        critDamage = 0.5f;
        damageMulti = 1.0f;

        actionBar = 30.0f;

        progressActionBar = true;
	}
	
	void Update ()
    {
        if (!gameObject.transform.localPosition.Equals(targetPos))
        {
            incrementPos();
            inPosition = false;
        }
        else
            inPosition = true;

        if (progressActionBar)
        {
            if (actionBar < 100.0f && alive)
            {
                actionBar += (float)speed * Time.deltaTime;

                if (actionBar >= 100.0f)
                    actionBar = 100.0f;
            }

            if (actionBar >= 100.0f)
                ready = true;
            else
                ready = false;
        }

        attack = (int)(baseStrength * dmgStr + baseDex * dmgDex);
        speed = (int)(baseDex * spdDex);
        critRate = baseDex * critDex;

        if (maxHP < 0)
            maxHP = 0;
        if (maxHP < HP)
            HP = maxHP;
        if (HP <= 0)
        {
            HP = 0;
            alive = false;
        }
        if (actionBar < 0.0f)
            actionBar = 0.0f;
        if (attack < 0)
            attack = 0;
        if (speed < 0)
            speed = 0;

        if (!alive)
        {
            ready = false;
            actionBar = 0.0f;

            Effect[] effectsToRemove = gameObject.GetComponents<Effect>();
            for (int i = 0; i < effectsToRemove.Length; i++)
                effectsToRemove[i].expire();

            gameObject.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 1.0f);
        }
    }

    void initSkill()
    {
        switch(id)
        {
            case ("hero1"):
                switch(GameObject.FindObjectOfType<SkillDictionary>().getSkill(id))
                {
                    case (1):
                        gameObject.AddComponent<OffenseSkill>();
                        break;
                    case (2):
                        gameObject.AddComponent<DefenseSkill>();
                        break;
                    case (3):
                        gameObject.AddComponent<SupportSkill>();
                        break;
                }
                break;
        }
    }

    public void incrementPos()
    {
        Vector2 currentPos = gameObject.transform.localPosition;

        gameObject.transform.localPosition = Vector2.MoveTowards(currentPos, targetPos, 3.0f);
    }

    public void applyDamage(float damage, bool physical)
    {
        if (HP > 0)
        {
            int finalDamage = (int)calculateDamage(damage, physical);
            HP -= finalDamage;

            /*
            IncreaseDamageDebuff[] debuffsToRemove = gameObject.GetComponents<IncreaseDamageDebuff>();
            for (int i = 0; i < debuffsToRemove.Length; i++)
                debuffsToRemove[i].expire();
            */
            Instantiate(Resources.Load<GameObject>("Prefabs/Hit"), new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity, gameObject.transform);

            GameObject floatingDamageText = Instantiate(Resources.Load<GameObject>("Prefabs/DamageText") as GameObject, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 20), Quaternion.identity, gameObject.transform);
            floatingDamageText.GetComponent<Text>().text = finalDamage.ToString();
            //floatingDamageText.GetComponent<DamageText>().target = gameObject;
        }
    }

    public void applyCritDamage(float damage, bool physical)
    {
        if (HP > 0)
        {
            int finalDamage = (int)calculateDamage(damage, physical);
            HP -= finalDamage;

            /*
            IncreaseDamageDebuff[] debuffsToRemove = gameObject.GetComponents<IncreaseDamageDebuff>();
            for (int i = 0; i < debuffsToRemove.Length; i++)
                debuffsToRemove[i].expire();
            */
            Instantiate(Resources.Load<GameObject>("Prefabs/Hit"), new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity, gameObject.transform);

            GameObject floatingDamageText = Instantiate(Resources.Load<GameObject>("Prefabs/DamageText") as GameObject, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 20), Quaternion.identity, gameObject.transform);
            floatingDamageText.GetComponent<Text>().text = "\b" + finalDamage.ToString() + "!\b";
            floatingDamageText.GetComponent<Text>().fontSize = 80;
            //floatingDamageText.GetComponent<DamageText>().target = gameObject;
        }
    }

    public float calculateDamage(float damage, bool physical)
    {
        float finalDamage;

        if (physical == true)
        {
            finalDamage = Mathf.Round((damage - defense) * damageMulti);
            Debug.Log("Damage: " + damage + "\nDef: " + defense);
        }
        else
        {
            finalDamage = Mathf.Round((damage - resist) * damageMulti);
            Debug.Log("Damage: " + damage + "\nRes: " + resist);
        }

        Debug.Log("Final Damage: " + finalDamage);

        if (finalDamage <= 0.0f)
            return 1.0f;
        else
            return finalDamage;
    }
    
    public bool calculateCrit()
    {
        if (Random.Range(0.0f, 1.0f) <= critRate)
            return true;
        else
            return false;
    }

    public void stopActionBar()
    {
        progressActionBar = false;
    }

    /*
    public bool getReady()
    {
        return ready;
    }
    public float getActionBar()
    {
        return actionBar;
    }
    public int getMaxHP()
    {
        return maxHP;
    }
    public int getHP()
    {
        return HP;
    }
    public int getAttack()
    {
        return attack;
    }
    public bool getAlive()
    {
        return alive;
    }
    public bool getInPosition()
    {
        return inPosition;
    }
    public float getCritRate()
    {
        return critRate;
    }
    */
}
