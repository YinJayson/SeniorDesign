using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats
{
    public string spriteName;
    public int strength;
    public int dex;
    public int intelligence;
    public bool basicAttackType;
    public int goldValue;
    public int expValue;
    public int level;
    public int exp;
    public int skillPoints;
    public int expToLevel;


    /* Constructors */
    // Used for everyone, generally enemies
    public CharacterStats(string sprite, int s, int d, int i, bool atkType, int g, int e)
    {
        spriteName = sprite;
        strength = s;
        dex = d;
        intelligence = i;
        goldValue = g;
        expValue = e;

        level = 1;
        exp = 0;
        skillPoints = 0;

        expToLevel = level * level;
    }

    // Used for player characters
    public CharacterStats(string sprite, int s, int d, int i, bool atkType, int lvl, int exp, int SP)
    {
        spriteName = sprite;
        strength = s;
        dex = d;
        intelligence = i;
        goldValue = 0;
        expValue = 0;

        level = 1;
        exp = 0;
        skillPoints = 0;

        expToLevel = level * level;
    }

    public void addEXP(int expToAdd)
    {
        exp += expToAdd;

        while(exp >= expToLevel)
            levelUp();
    }

    public void levelUp()
    {
        Debug.Log(exp + " - " + expToLevel);
        exp -= expToLevel;
        level++;
        skillPoints++;
        expToLevel = level * level;
    }
}