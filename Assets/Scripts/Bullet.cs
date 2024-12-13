using UnityEngine;
public class Bullet : MonoBehaviour
{
    public float speed = 10f; // Bullet speed
    public float lifetime = 5f; // How long the bullet exists before being destroyed
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Move the bullet in the direction it's facing
        rb.linearVelocity = transform.up * speed;  // Using transform.up to move in the direction the bullet is facing
        // Destroy the bullet after its lifetime ends
        Destroy(gameObject, lifetime);
    }
}
