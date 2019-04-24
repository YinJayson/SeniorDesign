using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableHeal {
    public int healAmount { get; set; }
    public bool affectsTeam { get; set; }

    public ConsumableHeal(int healAmount, bool affectsTeam)
    {
        this.healAmount = healAmount;
        this.affectsTeam = affectsTeam;
    }
}
