using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public int level;
    public float upgradeCostPerLevel;
    protected float health; //never call this EVER, always use the healthProp instead. I'll add later the healthbar and the healthProp is needed for that
    public float healthBonusPerLevel; //the bonus of rGR(resourceGenerateRate) added per level
    protected float healthProp
    {
        get { return health; }
        set { health = value; }
    }
    [SerializeField] protected float maxHealth;
    [SerializeField] protected float regenRate;
    public float placementCost;
    void Start()
    {
        health = maxHealth;
        InvokeRepeating("Regen", 1f, 1f);
    }
    void Regen()
    {
        if (healthProp + regenRate < maxHealth)
        {
            healthProp += regenRate;
        }
        else
        {
            healthProp = maxHealth;
        }
    }
    public void takeDamage(Bullet bullet)
    {
        healthProp -= bullet.damage;
        if (healthProp <= 0)
        {
            Destroy(gameObject); //temporary
        }
    }
    public abstract void Upgrade();
}
