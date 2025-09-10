using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    public EnemyManager enemyManager { get; private set; }

    public float maxHealth = 2f;
    float currentHealth;

    void Awake()
    {
        enemyManager = GetComponent<EnemyManager>();
        
        currentHealth = maxHealth;
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
            Die();
    }

    public void Die()
    {
        EventManager.OnEnemyDeath?.Invoke();
        enemyManager.ReturnToPool(gameObject);
    }
}
