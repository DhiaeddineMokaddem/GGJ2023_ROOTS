using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageTaker : MonoBehaviour
{
    [SerializeField] Enemy myEnemy;
    [SerializeField] GameObject hitVFX;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BulletAlly"))
        {
            Instantiate(hitVFX, other.transform.position, Quaternion.identity);
            myEnemy.takeDamage(other.transform.GetComponent<Bullet>());
            Destroy(other.gameObject);
        }
    }
}
