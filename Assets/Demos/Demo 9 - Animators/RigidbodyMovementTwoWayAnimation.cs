using UnityEngine;

public class RigidbodyMovementTwoWayAnimation: MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator animator;//New line ------------------------------------------------
    SpriteRenderer spriteRenderer;//New line ------------------------------------------------

    bool isMoving = false; //New line ------------------------------------------------

    float moveSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();//New line ------------------------------------------------
        spriteRenderer = GetComponent<SpriteRenderer>();//New line ------------------------------------------------
    }

    // Update is called once per frame
    void Update()
    {
        float moveInputX = Input.GetAxisRaw("Horizontal"); // For horizontal movement (left/right)
        float moveInputY = Input.GetAxisRaw("Vertical");   // For vertical movement (up/down)

        // Normalise the vector so that we don't move faster when moving diagonally.
        Vector2 moveDirection = new Vector2(moveInputX, moveInputY);
        moveDirection.Normalize();

        // Assign velocity directly to the Rigidbody
        rb2d.velocity = moveDirection * moveSpeed;

        // Tell the animator if we're moving
        if (rb2d.velocity.magnitude > 0.1f)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        animator.SetBool("IsMoving", isMoving);

        //Flip the sprite based on the direction we move in
        if (rb2d.velocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (rb2d.velocity.x < 0)
        {
            spriteRenderer.flipX = true; 
        }
    }
}
