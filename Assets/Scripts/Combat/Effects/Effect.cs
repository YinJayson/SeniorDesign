using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Effect
{
    void effect();
    void expire();
    void onHit();
    void setMaxDuration(float maxDuration);
    void setDuration(float duration);
    void setIntensity(float intensity);
    float getMaxDuration();
    float getDuration();
    float getIntensity();
}
