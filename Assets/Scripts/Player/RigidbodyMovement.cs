using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{
    public Rigidbody2D rb2d { get; private set; }

    public bool IsMoving { get; private set; } = false;
    public bool FacingRight { get; private set; } = true;

    [SerializeField] float moveSpeed = 4f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
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
            IsMoving = true;
        }
        else
        {
            IsMoving = false;
        }
    }
}
