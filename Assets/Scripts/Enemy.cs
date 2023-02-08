using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Bullet Projectile;
    public Transform target;
    public List<Transform> targets = new();
    [SerializeField] private float speed;
    private float health; //never call this EVER, always use the healthProp instead. I'll add later the healthbar and the healthProp is needed for that
    protected float healthProp
    {
        get { return health; }
        set { health = value; }
    }
    [SerializeField] private int maxHealth;
    [SerializeField] private int range;
    public int damage;
    [SerializeField] private float attackRate; // Attack rate in seconds
    private float attackTimer;
    void Start()
    {
        attackTimer = 0f;
        healthProp = maxHealth;
    }
    void Update()
    {  
        if(attackTimer > 0f)
        {
            attackTimer -= Time.deltaTime;
        }
        if (targets.Count > 0)
        {
            if (targets[0] == null)
            {
                targets.RemoveAt(0);
            }
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
        //instansiate bullet going in the direction of the target
        Bullet x = Instantiate(Projectile, transform.position, Quaternion.identity);
        x.target = targets[0];
        x.damage = damage;
    }
    private void Move()
    {
        transform.LookAt(target);
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
    public void takeDamage(Bullet bullet)
    {
        healthProp -= bullet.damage;
        if (healthProp <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("attackable"))
        {
            targets.Add(other.transform);
        }    
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("attackable"))
        {
            targets.Remove(other.transform);
        }
    }
}
