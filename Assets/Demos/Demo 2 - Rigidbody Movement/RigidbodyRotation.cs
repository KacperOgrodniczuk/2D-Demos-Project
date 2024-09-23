using UnityEngine;

public class RigidbodyRotation : MonoBehaviour
{
    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Only rotate if the Rigidbody is moving (to avoid snapping back to 0 rotation when stationary)
        if (rb2d.velocity.sqrMagnitude > 0.01f)
        {
            // Get the angle from the velocity direction
            float angle = Mathf.Atan2(rb2d.velocity.y, rb2d.velocity.x) * Mathf.Rad2Deg;

            // Apply rotation to the Rigidbody
            rb2d.MoveRotation(angle);
        }
    }
}
