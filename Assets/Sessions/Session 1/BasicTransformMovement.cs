using UnityEngine;

public class BasicTransformMovement : MonoBehaviour
{
    //Notes
    //This is not an ideal way to move your character, the movement is not normalised and therefore your character will move faster when moving diagonally.
    //Moving a charcter using transform is also not prefered, as it WILL cause issues with physics calculations.


    //Two floating point (decimals/integers up to certain precision) values to keep track of the values of pressed buttons.
    float xInput;       //We keep track of X movement for "left and right" movement.
    float yInput;       //We keep track of Y movement for "up and down" movement

    float movementSpeed = 0.25f;       //A value to determine how fast the object should be moving. Feel free to change this and experiment.

    // Update is called once per frame
    void Update()       //We use update to grab the input to ensure the check for it every frame.
    {
        //These functions allows us to grab input, we use the GetAxisRaw variant to get input without any smoothing, we than multiply this input by our movement speed amount.
        xInput = Input.GetAxisRaw("Horizontal") * movementSpeed;
        yInput = Input.GetAxisRaw("Vertical") * movementSpeed;
    }

    private void FixedUpdate()      //We move our object using fixed update, to ensure the character moves at a steady pace.
    {
        //We grab the current position of our object, assuming this code is attached to the player.
        Vector3 currentPosition = transform.position;

        currentPosition.x = currentPosition.x + xInput;     //add the new input to current position.
        currentPosition.y = currentPosition.y + yInput;     //add the new input to current position.

        transform.position = currentPosition;               //Apply the new position to the object this code is attached to.
    }
}
