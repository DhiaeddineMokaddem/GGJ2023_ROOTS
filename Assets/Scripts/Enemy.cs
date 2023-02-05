using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject Projectile;
    public Transform target;
    [SerializeField] private float speed;
    private int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private int range;
    [SerializeField] private int damage;
    [SerializeField] private float attackRate; // Attack rate in seconds
    private float attackTimer;
   
    void Start()
    {
        attackTimer = 0f;
        
    }

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
        else
        {
            Move();
        }
    }

    private void Attack()
    {
        Debug.Log("Attacking");
        //instansiate bullet going in the direction of the target
        Instantiate(Projectile, transform.position, Quaternion.identity,transform);


    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
    private void takeDamage()
    {
        {
            health -= damage;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
