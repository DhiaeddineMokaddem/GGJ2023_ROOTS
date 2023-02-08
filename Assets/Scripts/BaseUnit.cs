using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : Unit
{
    public static BaseUnit instance;
    public float waterGenerateRate;
    void Update()
    {
        Generate();
    }
    public override void Upgrade()
    {
        throw new System.NotImplementedException();
    }
    void Generate()
    {
        GameManager.instance.water += waterGenerateRate * Time.deltaTime;
    }
}
