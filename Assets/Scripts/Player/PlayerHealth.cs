using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth;
    float currentHealth;

    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = maxHealth;

        EventManager.OnHealthChange?.Invoke(currentHealth / maxHealth);
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;

        EventManager.OnHealthChange?.Invoke(currentHealth/maxHealth);

        if (currentHealth <= 0)
            Die();
    }

    public void Die()
    {
        UIManager.Instance.ShowGameOverUI();
    }
}
