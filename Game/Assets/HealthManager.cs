using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Debug.Log("Player defeated!");
            GameController.Instance.GameOver(); // Викликаємо гру закінчено
            Destroy(gameObject); // Знищте об'єкт гравця (якщо потрібно)
        }

        Debug.Log($"Player health: {currentHealth}");
    }

    public float GetHealth()
    {
        return currentHealth;
    }
}
