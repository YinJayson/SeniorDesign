using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Skill
{
    void skill();
    void skillCooldown();
    bool getReady();
    int getType();
    float getCooldown();
    float getElapsed();
}
