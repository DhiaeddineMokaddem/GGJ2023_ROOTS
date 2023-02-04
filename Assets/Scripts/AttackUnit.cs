using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AttackUnit : Unit
{
    // Start is called before the first frame update
    private int range = 5;
    private int damage = 10;
    [SerializeField] private float attackRate = 1f; // Attack rate in seconds
    private float attackTimer = 0f;
    [SerializeField] private Transform target;
    void Start()
    {
        health = maxHealth;
        
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
}
