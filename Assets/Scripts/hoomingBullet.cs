using UnityEngine;

public class hoomingBullet : MonoBehaviour
{
    public Transform target;  // The target to follow
    public float speed;  // The speed of the projectile
    public float rotationSpeed;  // The speed at which the projectile rotates towards the target

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
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

        // Rotate towards target
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

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
        Destroy(gameObject);
    }
}