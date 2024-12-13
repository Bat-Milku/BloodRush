using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;  // Bullet prefab
    public Transform gunTransform;  // Gun transform
    public Transform gunBarrelTransform;  // Gun barrel transform (end of the barrel)
    public float bulletSpeed = 10f;  // Speed of the bullet

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))  // Left mouse click
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Get the mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;  // Make sure the bullet stays in the 2D plane

        // Calculate the direction from the gun barrel to the mouse
        Vector3 shootDirection = (mousePosition - gunBarrelTransform.position).normalized;

        // Instantiate the bullet at the gun barrel's position
        GameObject bullet = Instantiate(bulletPrefab, gunBarrelTransform.position, Quaternion.identity);

        // Add velocity to the bullet so it moves in the direction of the mouse
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
    }


}