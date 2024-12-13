using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // Bullet speed
    public float lifetime = 2f; // How long the bullet exists before being destroyed

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Move the bullet in the direction it's facing
        rb.linearVelocity = transform.right * speed;

        // Destroy the bullet after its lifetime ends
        Destroy(gameObject, lifetime);
    }
}
