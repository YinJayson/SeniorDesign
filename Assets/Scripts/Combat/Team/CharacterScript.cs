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
    public int maxHP;
    public int HP;
    public int attack;
    public int baseAttack;
    public int wpnAttack = 0;
    public int speed;
    public bool basicAttackType;
    public float critRate;
    public float critDamage;
    public float cdReduction;

    public List<float> defMultis;
    public int defense;
    public int resist;

    public List<float> dmgMultis;
    public float dmgReduction;   // Overall Damage = 1 - damageMulti

    public bool stunned;         // Stunned effect prevents char from switching positions

    // Change these values to balance stats
    public const float dmgStr = 0.75f;
    public const float dmgDex = 0.75f;
    public const float dmgInt = 0.75f;
    public const float hpStr = 3.75f;
    public const float spdDex = 2.5f;
    public const float critDex = 0.0175f;
    public const float cooldownInt = 0.02f;

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

        /* init base stats */
        baseStrength = charStats.strength;
        baseDex = charStats.dex;
        baseIntelligence = charStats.intelligence;
        basicAttackType = charStats.basicAttackType;
        goldValue = charStats.goldValue;
        expValue = charStats.expValue;
        baseAttack = Mathf.RoundToInt(baseStrength * dmgStr + baseDex * dmgDex + baseIntelligence * dmgInt);
        baseMaxHP = Mathf.RoundToInt(baseStrength * hpStr);

        /* init stats */
        strength = baseStrength;
        dex = baseDex;
        intelligence = baseIntelligence;

        /* Equipment */
        if (FindObjectOfType<EquipDictionary>().dictionary.ContainsKey(id))
        {
            EquipmentDictionary equipmentDict = FindObjectOfType<EquipmentDictionary>();
            EquippedItems equipped = FindObjectOfType<EquipDictionary>().dictionary[id];
            defense = equipmentDict.armorDictionary[equipped.helm].getDefense() + equipmentDict.armorDictionary[equipped.armor].getDefense() + equipmentDict.armorDictionary[equipped.pants].getDefense();
            resist = equipmentDict.armorDictionary[equipped.helm].getResist() + equipmentDict.armorDictionary[equipped.armor].getResist() + equipmentDict.armorDictionary[equipped.pants].getResist();
            wpnAttack = equipmentDict.weaponDictionary[equipped.weapon].getAttack();//GetByName(FindObjectOfType<EquipDictionary>().dictionary[id].equipped[3]).getAtk();
            basicAttackType = equipmentDict.weaponDictionary[equipped.weapon].getAtkType();//GetByName(FindObjectOfType<EquipDictionary>().dictionary[id].equipped[3]).getAtkType();
        }

        attack = baseAttack + wpnAttack;

        // Strength related
        maxHP = baseMaxHP;
        if (GameObject.FindObjectOfType<HealthDictionary>().dictionary.ContainsKey(id))
            HP = GameObject.FindObjectOfType<HealthDictionary>().getHealth(id);
        else
            HP = maxHP;

        // Dex related
        speed = Mathf.RoundToInt(dex * spdDex);
        critRate = dex * critDex;
        critDamage = 0.5f;

        // Int related
        cdReduction = cooldownInt * intelligence;

        dmgReduction = 0.0f;
        alive = true;
        ready = false;
        inPosition = true;
        actionBar = 30.0f;

        stunned = false;
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
            if (actionBar < 100.0f && alive && !stunned)
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

        baseAttack = Mathf.RoundToInt(baseStrength * dmgStr + baseDex * dmgDex + baseIntelligence * dmgInt);
        attack = baseAttack + wpnAttack;
        speed = Mathf.RoundToInt(dex * spdDex);
        critRate = dex * critDex;

        /* Calculates damage multiplier */
        float dmgMulti = 0.0f;
        for (int i = 0; i < dmgMultis.Count; i++)
        {
            dmgMulti += (1 - dmgMulti) * dmgMultis[i];
        }

        dmgReduction = dmgMulti;
        //////////////////////////////////
        
        /* Calculates defense */
        float defMulti = 1.0f;
        for (int i = 0; i < defMultis.Count; i++)
        {
            defMulti += defMultis[i];
        }
        if (defMulti < 0.0f)
            defMulti = 0.0f;

        defense = Mathf.RoundToInt(defense * defMulti);
        resist = Mathf.RoundToInt(resist * defMulti);
        ////////////////////////
        
        dmgReduction = dmgMulti;
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
                        gameObject.AddComponent<SkillOffense>();
                        break;
                    case (2):
                        gameObject.AddComponent<SkillDefense>();
                        break;
                    case (3):
                        gameObject.AddComponent<SkillSupport>();
                        break;
                }
                break;
            case ("hero2"):
                switch(GameObject.FindObjectOfType<SkillDictionary>().getSkill(id))
                {
                    case (1):
                        gameObject.AddComponent<SkillMomentum>();
                        break;
                    case (2):
                        gameObject.AddComponent<SkillHardcover>();
                        break;
                    case (3):
                        gameObject.AddComponent<SkillHeavy>();
                        break;
                }
                break;
            case ("hero3"):
                switch (GameObject.FindObjectOfType<SkillDictionary>().getSkill(id))
                {
                    case (1):
                        gameObject.AddComponent<SkillCorrosion>();
                        break;
                    case (2):
                        gameObject.AddComponent<SkillSticky>();
                        break;
                    case (3):
                        gameObject.AddComponent<SkillRegeneration>();
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

    public void applyDamage(float damage, bool physical, bool crit, CharacterScript source)
    {
        if (HP > 0)
        {
            int finalDmg = Mathf.RoundToInt(damage);
            if (finalDmg <= 0)
                finalDmg = 1;
            HP -= finalDmg;

            // Damage Text initialization
            if (crit)
            {
                GameObject floatingDamageText = Instantiate(Resources.Load<GameObject>("Prefabs/DamageText") as GameObject, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 20), Quaternion.identity, gameObject.transform);
                floatingDamageText.GetComponent<Text>().text = finalDmg.ToString();
                floatingDamageText.GetComponent<Text>().text = "\b" + finalDmg.ToString() + "!\b";
                floatingDamageText.GetComponent<Text>().fontSize = 20;
            }
            else
            {
                GameObject floatingDamageText = Instantiate(Resources.Load<GameObject>("Prefabs/DamageText") as GameObject, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 20), Quaternion.identity, gameObject.transform);
                floatingDamageText.GetComponent<Text>().text = finalDmg.ToString();
            }

            if(gameObject.GetComponent<Effect>() != null)
                gameObject.BroadcastMessage("onHit");
        }
    }
    public void applyHeal(int healAmount)
    {
        if (healAmount <= 0)
            healAmount = 1;
        HP += healAmount;

        GameObject floatingDamageText = Instantiate(Resources.Load<GameObject>("Prefabs/DamageText") as GameObject, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 20), Quaternion.identity, gameObject.transform);
        floatingDamageText.GetComponent<Text>().text = healAmount.ToString();
        floatingDamageText.GetComponent<Text>().color = new Color(0.0f, 1.0f, 0.0f);
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
