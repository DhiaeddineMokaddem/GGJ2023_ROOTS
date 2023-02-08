using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageTaker : MonoBehaviour
{
    [SerializeField] Enemy myEnemy;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BulletAlly"))
        {
            myEnemy.takeDamage(other.transform.GetComponent<hoomingBullet>());
        }
    }
}
