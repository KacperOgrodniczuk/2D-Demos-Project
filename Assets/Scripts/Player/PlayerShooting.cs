using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab of the bullet
    public Transform firePointRotation;     // The position where bullets are spawned
    public Transform bulletSpawnPoint;
    public float projectileSpeed = 20f; // Speed of the bullet
    public float attackRate = 2f;
    public float attackDamage = 1f;

    AudioSource audioSource;    //The source attached to this gameobject. 
    public AudioClip attackSound;   //The sound effect that will play whenever a magic missile is shot.

    [Header("Timer Variables")]
    float lastTimeShot;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (UIManager.isPaused)     // If the game is supposed to be paused ignore the rest of the code.
            return;

        RotateBulletSpawnPointTowardsMouse();

        if (CanShoot())
            Shoot();
    }

    void RotateBulletSpawnPointTowardsMouse()
    {

        // Get the mouse position in screen space and convert it to world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Ensure z-axis is 0 for 2D space

        // Calculate the direction from the player to the mouse
        Vector2 direction = (mousePosition - firePointRotation.position).normalized;

        // Calculate the angle to rotate the fire point (using Atan2 to get angle in degrees)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply the rotation to the fire point
        firePointRotation.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    bool CanShoot()
    {
        return Input.GetButton("Fire1") && Time.time >= lastTimeShot + attackRate;
    }

    void Shoot()
    {
        //Play the attach sound whenever we shoot.
        audioSource.PlayOneShot(attackSound);

        lastTimeShot = Time.time;

        // Instantiate the bullet at the fire point's position and rotation
        // All prefabs by default should be facing the right side. 2D, right is treated as forward in 3D
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, firePointRotation.rotation);

        // Adjust the rotation of the bullet to face right (if it's not facing the right direction by default)
        bullet.transform.rotation = Quaternion.Euler(0, 0, firePointRotation.rotation.eulerAngles.z + bulletPrefab.transform.rotation.eulerAngles.z);  // Correct the sprite rotation

        // Shoot the bullet passing through neccessary values
        bullet.GetComponent<MagicMissile>().Shoot(firePointRotation.right, projectileSpeed, attackDamage);
    }
}
