using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject Projectile;
    public Transform target;
    [SerializeField] private float speed;
    private float health;
    [SerializeField] private int maxHealth = 50;
    [SerializeField] private int range;
    public int damage;
    [SerializeField] private float attackRate; // Attack rate in seconds
    private float attackTimer;
    
    //make array of transform named targets




    void Start()
    {
        attackTimer = 0f;
        health = maxHealth;
    }

    void Update()
    {
        if (!target)
        {
            target = GameObject.FindGameObjectWithTag("attackable").transform;
        }
        //assign the target to the nearest game object with "attackable" tag
        
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
        transform.LookAt(target);
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
    private void takeDamage(float takenDmg)
    {
        {
            health -= takenDmg;
            if (health <= 0)
            {
            
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("attackable"))
        {
            target = other.transform;
        }
        if (other.CompareTag("BulletAlly"))
        {
            takeDamage(10);
        }
        
    }
}
