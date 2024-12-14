using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]         //Tell Unity to add theses components to the gameobject this code is attached to.
public class RigidbodyMovementEightWayAnimation : MonoBehaviour
{
    Animator animator;//New line ------------------------------------------------
    Rigidbody2D rb2d;
    public float moveSpeed = 5f;

    void Start()
    {
        animator = GetComponent<Animator>();//New line ------------------------------------------------
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveInputX = Input.GetAxisRaw("Horizontal"); // For horizontal movement (left/right)
        float moveInputY = Input.GetAxisRaw("Vertical");   // For vertical movement (up/down)

        animator.SetFloat("InputX", moveInputX);//New line ------------------------------------------------
        animator.SetFloat("InputY", moveInputY);//New line ------------------------------------------------

        // Normalise the vector so that we don't move faster when moving diagonally.
        Vector2 moveDirection = new Vector2(moveInputX, moveInputY);
        moveDirection.Normalize();

        // Assign velocity directly to the Rigidbody
        rb2d.velocity = moveDirection * moveSpeed;
    }
}
