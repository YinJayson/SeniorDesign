using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Effect
{
    void effect();
    void expire();
    void onHit();
    float getMaxDuration();
    float getDuration();
}
