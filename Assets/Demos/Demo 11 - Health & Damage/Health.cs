using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;           //We will use this to set the max health value in the inspector
    int currentHealth;          //Hidden number to keep track of current health

    private void Start()
    {
        currentHealth = maxHealth;      //We set the current health to whatever the max allowed health is.
    }

    public void TakeDamage(int damage)      // We will use this function to change our health. It needs to be public so that other scripts can see it.
    { 
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()      //This function will mandate what happens when the enemy/player dies.
    { 
        Destroy(gameObject);
    }
}