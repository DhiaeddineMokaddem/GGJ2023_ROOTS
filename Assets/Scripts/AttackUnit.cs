using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AttackUnit : Unit
{
    public float[] Attackplant = { 5f, 10f, 10f };// 0upgrade worth/1plant max health/2attack dmg
    // Start is called before the first frame update
    [SerializeField] private int range = 5;
    [SerializeField] private GameObject Projectile;
    [SerializeField] public int damage = 10;
    [SerializeField] private float attackRate = 1f; // Attack rate in seconds
    private float attackTimer = 0f;
    [SerializeField] public Transform target;
    void Start()
    {
        health = Attackplant[1];
        InvokeRepeating("Regen", 1f, 1f);
        if (!target)
        {
            target = GameObject.FindGameObjectWithTag("enemy").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (target)
        {
            transform.LookAt(target);
            if (Vector3.Distance(transform.position, target.position) <= range)
        {
            if (attackTimer <= 0f)
            {
                Attack();
                attackTimer = attackRate;
            }
        }
        }
        attackTimer -= Time.deltaTime;
        
    }
    void Attack()
    {
        if (target)
        {
            Instantiate(Projectile, transform.position, Quaternion.identity, transform);
        Debug.Log(" Unit Attacking enemy");
        }
        
    }
    void Regen()
    {
        if (health < Attackplant[1])
        {
            health += regenRate;
        }
    }
    void takeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            //Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            target = other.transform;
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            takeDamage(1);
            Debug.Log("Unit took damage");
        }
    }
}
