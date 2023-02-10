using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public Tile myTile;
    public int level;
    public float upgradeCostPerLevel;
    protected float health; //never call this EVER, always use the healthProp instead. I'll add later the healthbar and the healthProp is needed for that
    public float healthBonusPerLevel; //the bonus of rGR(resourceGenerateRate) added per level
    protected float healthProp
    {
        get { return health; }
        set 
        {
            health = value; 
            healthBar.SetHealth(health);
        }
    }
    [SerializeField] protected float maxHealth;
    protected float maxHealthProp
    {
        get { return maxHealth; }
        set
        {
            maxHealth = value;
            healthBar.SetMaxHealth(maxHealth);
        }
    }
    [SerializeField] protected float regenRate;
    public float placementCost;
    [SerializeField] private HealthBar healthBar;
    public void Start()
    {
        healthBar.SetMaxHealth(maxHealthProp);
        healthProp = maxHealthProp;
        InvokeRepeating("Regen", 1f, 1f);
    }
    void Regen()
    {
        if (healthProp + regenRate < maxHealthProp)
        {
            healthProp += regenRate;
        }
        else
        {
            healthProp = maxHealthProp;
        }
    }
    public void takeDamage(Bullet bullet)
    {
        healthProp -= bullet.damage;
        if (healthProp <= 0)
        {
            die();
        }
    }
    public virtual void Upgrade()
    {
        level++;
        healthProp /= maxHealthProp;
        maxHealthProp += healthBonusPerLevel;
        healthProp *= maxHealthProp;
    }
    public virtual void die()
    {
        myTile.UnspawnUnit();
        Destroy(gameObject);
    }
}
