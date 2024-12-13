using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform gunBarrelTransform;

    public float bulletSpeed = 10f;
    public float bulletLifeTime = 5f;
    public float stationaryBulletSpeed = 5f;

    private float timeBetweenShots = 0.1f;
    private float shotTimer = 0f;

    void Update()
    {
        if (Input.GetMouseButton(0)) // Left mouse button for shooting
        {
            shotTimer -= Time.deltaTime;

            if (shotTimer <= 0)
            {
                Shoot();
                shotTimer = timeBetweenShots;  // Reset the shot timer
            }
        }
    }

    void Shoot()
    {
        // Instantiate the bullet at the gun barrel's position and rotation
        GameObject bullet = Instantiate(bulletPrefab, gunBarrelTransform.position, gunBarrelTransform.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();

        // Get player movement to apply to bullet speed
        Vector2 movement = GetComponent<PlayerController>().movement;

        // Set bullet velocity based on whether the player is moving or not
        if (movement.sqrMagnitude > 0) // If the player is moving
        {
            bulletRb.linearVelocity = gunBarrelTransform.right * bulletSpeed * Time.timeScale;
        }
        else // If the player is not moving
        {
            bulletRb.linearVelocity = gunBarrelTransform.right * stationaryBulletSpeed * Time.timeScale;
        }

        // Set the rotation of the bullet using Euler angles to ensure it's aligned correctly
        // Calculate the rotation angle from the gun's direction
        float angle = Mathf.Atan2(gunBarrelTransform.up.y, gunBarrelTransform.up.x) * Mathf.Rad2Deg;

        // Apply the Euler rotation to the bullet
        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Destroy the bullet after some time
        Destroy(bullet, bulletLifeTime);
    }
}
