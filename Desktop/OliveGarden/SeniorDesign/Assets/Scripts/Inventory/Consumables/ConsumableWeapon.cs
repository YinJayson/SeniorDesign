using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableWeapon {
    public int attack { get; set; }
    public bool affectsTeam { get; set; }

    public ConsumableWeapon(int attack, bool affectsTeam)
    {
        this.attack = attack;
        this.affectsTeam = affectsTeam;
    }

}
