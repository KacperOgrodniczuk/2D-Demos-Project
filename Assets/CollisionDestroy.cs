using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDestroy : MonoBehaviour
{
    public GameObject doorWall;

    void OnTriggerEnter2D(Collider2D collider)
    {
        // Only if we collided with the player
        if(collider.gameObject.CompareTag("Player"))
        {
            doorWall.SetActive(false);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        // Only if we collided with the player
        if(collider.gameObject.CompareTag("Player"))
        {
            doorWall.SetActive(true);
        }
    }
}
