using UnityEngine;

public class EnemyCollisionDamage : MonoBehaviour
{
    public float damage;    //Enemy damage

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If we collided with the player, grab the health script and deal damage.
        if (collision.gameObject.CompareTag("Player"))
        {
            // The below line of code tries to find a health script on
            // the player object and deal damage if it finds one.
            collision.gameObject.GetComponent<PlayerHealth>()?.TakeDamage(damage);
        }
    }
}
