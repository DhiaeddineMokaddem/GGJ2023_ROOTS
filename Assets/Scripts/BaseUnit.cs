using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : Unit
{
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        regenRate = 2f;
        InvokeRepeating("Regen", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void takeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    void Regen()
    {
        if (health < maxHealth)
        {
            Debug.Log("Main tree regen");
            health += regenRate;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            takeDamage(10);
            Debug.Log("base took damage");
        }
    }
}
