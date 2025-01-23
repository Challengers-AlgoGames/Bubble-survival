using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Header Setting")]
    public int maxHealth = 100;
    private int currentHealth;

    private bool isHit = false;

    public delegate void HealthCHanged(int currentHealth, int maxHealth);
    public event HealthCHanged OnHealthChanged;

    private void Start()
    {
        currentHealth = maxHealth;
        Debug.Log($"currenthealth : {currentHealth} / {maxHealth}");
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bubble"))
        {
            Debug.Log("Collision");
            TakeDamage(10);
        }
    }

    private void TakeDamage(int damage)
    {
        if (damage <= 0) return;
        currentHealth -= damage;
        currentHealth = Math.Clamp(currentHealth, 0, maxHealth);

        Debug.Log($"damage : {damage} currentHealth : {currentHealth}");

        OnHealthChanged?.Invoke(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Debug.Log("Player has died");
    }
}
