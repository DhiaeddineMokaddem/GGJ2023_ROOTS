using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private int health;
    [SerializeField] private int maxHealth;
    [SerializeField] private int range;
    [SerializeField] private int damage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void takeDmg(int dmgAmount)
    {
        health -= dmgAmount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        Debug.Log(health);
    }
    private void Attack()
    {
        Debug.Log("Attacking");
    }
    private void Move()
    {
        Debug.Log("Moving");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Attackable"))
        {
            Debug.Log("unit in range");
        }
    }
}
