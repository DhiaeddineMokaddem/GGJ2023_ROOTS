using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTreeUnit : Unit
{
    public static MainTreeUnit instance;
    public float waterGenerateRate;
    public float wGRBonusPerLevel; //wGR mean waterGenerateRate
    void Update()
    {
        Generate();
    }
    public override void Upgrade()
    {
        base.Upgrade();
        waterGenerateRate += wGRBonusPerLevel;
    }
    void Generate()
    {
        GameManager.instance.water += waterGenerateRate * Time.deltaTime;
    }
    public override void die()
    {
        GameManager.instance.Lose();
    }
}
