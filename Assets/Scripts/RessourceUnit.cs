using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RessourceUnit : Unit
{
    public float resourceGenerateRate; //per second // resourceGenerateRate=unit.Recouceplant[2]
    public float rGRBonusPerLevel; //the bonus of rGR(resourceGenerateRate) added per level
    public void Generate(float addRate) //called in update of Tile.cs
    {
        GameManager.instance.water += addRate;
    }
    public override void Upgrade()
    {
        base.Upgrade();
        resourceGenerateRate += rGRBonusPerLevel;
    }
}
