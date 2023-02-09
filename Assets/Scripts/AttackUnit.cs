using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AttackUnit : Unit
{
    [SerializeField] private Bullet Projectile;
    [SerializeField] public float damage;
    [SerializeField] public float damageBonusPerLevel;
    [SerializeField] private float attackRate; // Attack rate in seconds
    [SerializeField] private float attackRateBonusPerLevel; // this should how a percentage decrease like 10% (aka 0.1, not literally 10)
    private float attackTimer;
    [SerializeField] GameObject attackLocation; //the point frrom which the bullets are spawned
    private List<Transform> targets = new();
    void Update()
    {
        if (attackTimer > 0)
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
        if (targets.Count > 0)
        {
            if (attackTimer <= 0)
            {
                Attack();
                attackTimer = attackRate;
            }
        }
    }
    void Attack()
    {
        Bullet x = Instantiate(Projectile, attackLocation.transform.position, Quaternion.identity);
        x.target = targets[0];
        x.damage = damage;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            targets.Add(other.transform);
        } 
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("enemy"))
        {
            targets.Remove(other.transform);
        }
    }
    public override void Upgrade()
    {
        base.Upgrade();
        damage += damageBonusPerLevel;
        attackRate -= (attackRateBonusPerLevel*attackRate);
    }
}
