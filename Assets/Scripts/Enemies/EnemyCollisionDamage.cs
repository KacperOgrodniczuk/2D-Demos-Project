using UnityEngine;

public class EnemyCollisionDamage : MonoBehaviour
{
    public float damage;    //Enemy damage

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If we collided with the player, grab the health script and deal damage.
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>()?.TakeDamage(damage);
        }
    }
}
