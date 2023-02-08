using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;  // The target to follow
    public float speed;  // The speed of the projectile
    public float damage;  // The damage the projectile deals on impact

    void Update()
    {
        if(target != null)
        {
            transform.forward = target.position - transform.position;
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //bullet is bullet now ! (ally and enemy share the same bullet script)
    //it will get destroyed by the enemy instead (in EnemyDamageTaker.cs / AllyDamageTaker.cs)

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "EnemyDamageDetector")
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}