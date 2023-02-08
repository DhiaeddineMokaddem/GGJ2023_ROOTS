using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject Projectile;
    public Transform target;
    public List<Transform> targets = new();
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
        if(attackTimer < 0f)
        {
            attackTimer -= Time.deltaTime;
        }

        if (targets.Count>0)
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
        Instantiate(Projectile, transform.position, Quaternion.identity);
    }

    private void Move()
    {
        transform.LookAt(target);
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
    public void takeDamage(hoomingBullet bullet)
    {
        {
            health -= bullet.myDamage;
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
            targets.Add(other.transform);
        }    
    }
}
