using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    public float maxHealth = 2f;
    public int scoreValue = 1;
    float currentHealth;

    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = maxHealth;
    }

    public void Heal(float healAmount)
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
            Die();
    }

    public void Die()
    {
        EventManager.OnEnemyDeath?.Invoke(scoreValue);
        //This will get replaced with a death animation at some point.
        Destroy(gameObject);
    }
}
