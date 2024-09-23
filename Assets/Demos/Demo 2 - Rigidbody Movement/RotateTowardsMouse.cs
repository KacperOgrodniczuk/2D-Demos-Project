using UnityEngine;

public class RotateTowardsMouse : MonoBehaviour
{
    Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get the mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction from the Rigidbody to the mouse
        Vector2 direction = (mousePosition - transform.position).normalized;

        // Get the angle in degrees using Atan2
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the Rigidbody to face the mouse
        rb2d.MoveRotation(angle);
    }
}
