using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseUnit : Unit
{
    // Start is called before the first frame update
    public float waterGenerateRate;
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
    void Generate()
    {
        GameManager.instance.water += waterGenerateRate * Time.deltaTime;
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
