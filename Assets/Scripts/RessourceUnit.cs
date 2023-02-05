using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RessourceUnit : Unit
{
    public float[] Recouceplant = { 5f, 10f, 0.2f };// 0upgrade worth/1plant max health/2resourceGenerateRate
    [SerializeField] float resourceGenerateRate; //per second // resourceGenerateRate=unit.Recouceplant[2]
    void Start()
    {
        //resourceGenerateRate = unit.Recouceplant[2];
        
        InvokeRepeating("Generate", 1f, 1f);
        InvokeRepeating("Regen", 1f, 1f);
        health = Recouceplant[1];
    }
    private void Update()
    {
        //Generate(resourceGenerateRate*Time.deltaTime);// by aziz
        //Generate(Recouceplant[2] * Time.deltaTime); // by haithem
    }
    private void Regen()
    {
        if (health < Recouceplant[1])
        {
            Debug.Log("regen");
            health += regenRate;
        }
    }
    public void Generate(float addRate)
    {
        GameManager.instance.water += addRate;
    }
    private void takeDmg(int dmgAmount)
    {
        health -= dmgAmount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        Debug.Log(health);
        
    }
}
