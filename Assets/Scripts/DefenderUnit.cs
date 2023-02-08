using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderUnit : Unit
{
    public override void Upgrade()
    {
        level++;
        healthProp /= maxHealth;
        maxHealth += healthBonusPerLevel;
        healthProp *= maxHealth;
    }
}
