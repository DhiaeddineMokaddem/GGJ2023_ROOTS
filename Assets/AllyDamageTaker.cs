using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyDamageTaker : MonoBehaviour
{
    [SerializeField] Unit myUnit;
    [SerializeField] GameObject hitVFX;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BulletEnemy"))
        {
            Instantiate(hitVFX, other.transform.position, Quaternion.identity);
            myUnit.takeDamage(other.transform.GetComponent<Bullet>());
            Destroy(other.gameObject);
        }
    }
}
