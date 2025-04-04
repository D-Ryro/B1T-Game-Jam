using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public void Initialize(float health)
    {
        maxHealth = health;
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) Die();
    }

    void Die()
    {
        Destroy(gameObject);
    }
}