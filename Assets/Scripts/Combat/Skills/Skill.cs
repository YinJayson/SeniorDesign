using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Skill
{
    /*
     * string name
     * string description
     * float cooldown
     * bool ready
     * int type     // 1 = Offense, 2 = Defense, 3 = Support
     */

    void skill();
    void skillCooldown();
    string getTag();
    string getName();
    string getDescription();
    float getCooldown();
    float getElapsed();
    bool getReady();
    int getType();
}
