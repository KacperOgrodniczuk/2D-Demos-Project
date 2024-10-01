using UnityEngine;

public class CollisionDestruction : MonoBehaviour
{
    // If a collision happens do some code
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collision detected.");
            Destroy(gameObject);
        }
    }
}
