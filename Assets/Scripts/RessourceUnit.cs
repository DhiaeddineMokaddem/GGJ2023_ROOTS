using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RessourceUnit : Unit
{
    // Start is called before the first frame update
    
    
    void Start()
    {
        InvokeRepeating("Generate", 1f, 1f);
        InvokeRepeating("Regen", 1f, 1f);
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void Regen()
    {
        if (health < maxHealth)
        {
            Debug.Log("regen");
            health += regenRate;
        }
    }
    private void Generate()
    {
        Debug.Log("Generating ressources");
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
