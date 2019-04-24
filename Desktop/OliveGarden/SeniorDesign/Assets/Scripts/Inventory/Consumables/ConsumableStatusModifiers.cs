using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableStatusModifiers {
    public int statType { get; set; }
    public int intensity { get; set; }
    public int duration { get; set; }
    public bool affectsTeam { get; set; }

    public ConsumableStatusModifiers(int statType, int intensity, int duration, bool affectsTeam)
    {
        this.statType = statType;
        this.intensity = intensity;
        this.duration = duration;
        this.affectsTeam = affectsTeam;
    }

}
