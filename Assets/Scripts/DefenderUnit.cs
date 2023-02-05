using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderUnit : Unit
{
    public float[] deffenseplant = { 5f, 50f };//0upgrade worth/1plant health
    // Start is called before the first frame update    
    private float hp;
    void Start()
    {
        hp = deffenseplant[1];
        regenRate = 2f;
        InvokeRepeating("Regen", 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Regen()
    {
        if (health < deffenseplant[1])
        {
            Debug.Log("Defender regen");
            health += regenRate;
        }
    }
    void takeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            takeDamage(10);
            Debug.Log("Unit took damage");
        }
    }
}
