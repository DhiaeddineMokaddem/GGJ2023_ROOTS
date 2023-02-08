using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTreeUnit : Unit
{
    public static MainTreeUnit instance;
    public float waterGenerateRate;
    void Update()
    {
        Generate();
    }
    public override void Upgrade()
    {
        base.Upgrade();
    }
    void Generate()
    {
        GameManager.instance.water += waterGenerateRate * Time.deltaTime;
    }
}
