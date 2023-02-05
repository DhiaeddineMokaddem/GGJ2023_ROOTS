using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    protected float health;
    [SerializeField] protected float maxHealth;
    [SerializeField] protected float regenRate;
    public float placementCost;
    float[] Recouceplant = {5f,10f,0.2f };// 0upgrade worth/1plant health/2resourceGenerateRate
    float[] Attackplant = {5f,10f,10f };// 0upgrade worth/1plant health/2attack dmg
    float[] deffenseplant = {5f,50f };//0upgrade worth/1plant health
}
