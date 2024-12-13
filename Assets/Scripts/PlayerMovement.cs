using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    // Reference for rotation
    public Transform characterTransform;

    // Reference for gun rotation
    public Transform gunTransform;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Handle movement input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Rotate the player towards the mouse
        RotatePlayerWithMouse();

        // Rotate the gun towards the mouse (same method as for the player)
        RotateGunWithMouse();
    }

    void FixedUpdate()
    {
        // Move the player
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void RotatePlayerWithMouse()
    {
        // Get the mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction from the player to the mouse
        Vector3 direction = mousePosition - characterTransform.position;

        // Remove the z-axis component (to keep the rotation in 2D)
        direction.z = 0;

        // Calculate the angle between the player and the mouse position
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply the rotation to the player (rotation only)
        characterTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    void RotateGunWithMouse()
    {
        // Get the mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction from the gun to the mouse
        Vector2 direction = (mousePosition - gunTransform.position).normalized;

        // Calculate the angle to rotate the gun towards the mouse
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the gun to face the mouse
        gunTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
