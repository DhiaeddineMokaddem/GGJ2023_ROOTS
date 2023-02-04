using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RessourceUnit : Unit
{
    [SerializeField] float resourceGenerateRate; //per second
    void Start()
    {
        InvokeRepeating("Generate", 1f, 1f);
        InvokeRepeating("Regen", 1f, 1f);
        health = maxHealth;
    }
    private void Update()
    {
        Generate(resourceGenerateRate*Time.deltaTime);
    }
    private void Regen()
    {
        if (health < maxHealth)
        {
            Debug.Log("regen");
            health += regenRate;
        }
    }
    private void Generate(float addRate)
    {
        GameManager.instance.waterResource += addRate;
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
