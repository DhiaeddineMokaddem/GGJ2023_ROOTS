using UnityEngine;

public class hoomingBullet : MonoBehaviour
{
    private Transform target;  // The target to follow
    public float speed;  // The speed of the projectile
    public float rotationSpeed;  // The speed at which the projectile rotates towards the target
    public float damage;  // The damage the projectile deals on impact
    public Transform hitVFX;
    private Rigidbody rb;
    public float myDamage;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //get script component from parent
        //transform.parent.GetComponent<Enemy>();
        // Get the target from the parent
        target = transform.parent.GetComponent<Enemy>().target;
        damage = transform.parent.GetComponent<Enemy>().damage;
    }

    void Update()
    {   
        
        if (target == null)
        {
            // If the target is null, do nothing
            return;
        }

        // Calculate direction towards target
        Vector3 direction = (target.position - transform.position).normalized;

        //// Rotate towards target
        //Quaternion lookRotation = Quaternion.LookRotation(direction);
        //transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

        // Apply force in direction of target
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.Impulse);

        // Limit the maximum speed of the projectile
        if (rb.velocity.magnitude > speed)
        {
            rb.velocity = rb.velocity.normalized * speed;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(hitVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}