using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AttackUnit : Unit
{
    // Start is called before the first frame update
    [SerializeField] private int range = 5;
    [SerializeField] private int damage = 10;
    [SerializeField] private float attackRate = 1f; // Attack rate in seconds
    private float attackTimer = 0f;
    [SerializeField] private Transform target;
    void Start()
    {
        health = maxHealth;
         if (!target)
        {
            target = GameObject.FindGameObjectWithTag("enemy").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        attackTimer -= Time.deltaTime;
        if (Vector3.Distance(transform.position, target.position) <= range)
        {
            if (attackTimer <= 0f)
            {
                Attack();
                attackTimer = attackRate;
            }
        }
    }
    void Attack()
    {
        Debug.Log(" Unit Attacking enemy");
    }
    void regen()
    {
        if (health < maxHealth)
        {
            health += regenRate;
        }
    }
    void takeDamage(int damage)
    {
        health -= damage;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            target = other.transform;
        }

    }
}
