using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Skill
{
    void skill();
    bool getReady();
    void skillCooldown();
}
