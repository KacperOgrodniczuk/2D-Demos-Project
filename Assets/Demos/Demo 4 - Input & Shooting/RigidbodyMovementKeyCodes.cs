using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]         //Tell Unity to add theses components to the gameobject this code is attached to.
[RequireComponent(typeof(BoxCollider2D))]       //We will still need to tweak some of the settings.
public class RigidbodyMovementKeyCodes : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float moveSpeed = 5f;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //reset the input values
        float moveInputX = 0;
        float moveInputY = 0;

        if (Input.GetKey(KeyCode.W))    // Input for moving up
            moveInputY = 1;
        if (Input.GetKey(KeyCode.S))    // Input for moving down
            moveInputY = -1;
        if (Input.GetKey(KeyCode.A))    // Input for moving left
            moveInputX = -1;
        if (Input.GetKey(KeyCode.D))    // Input for moving right
            moveInputX = 1;

        // Normalise the vector so that we don't move faster when moving diagonally.
        Vector2 moveDirection = new Vector2(moveInputX, moveInputY);
        moveDirection.Normalize();

        // Assign velocity directly to the Rigidbody
        rb2d.velocity = moveDirection * moveSpeed;
    }
}
