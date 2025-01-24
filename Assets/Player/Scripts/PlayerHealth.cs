using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static event Action OnPlayerDeath;

    [Header("Header Setting")]
    public int maxHeart = 3;
    private int currentHeart;

    public delegate void HealthCHanged(int currentHeart, int maxHeart);
    public event HealthCHanged OnHealthChanged;
    private HeartVisual heartVisual;
    private void Awake()
    {
        heartVisual = FindAnyObjectByType<HeartVisual>();
    }

    private void Start()
    {
        currentHeart = maxHeart;
        Debug.Log($"currentHeart : {currentHeart} / {maxHeart}");
        OnHealthChanged?.Invoke(currentHeart, maxHeart);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bubble"))
        {
            Debug.Log("Collision");
            heartVisual.TakeDamage(1);
            Destroy(collision.gameObject);
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Bubble"))
        {
            Debug.Log("Collision");
            heartVisual.TakeDamage(1);
        }
    }

    private void Die()
    {
        Debug.Log("Player has died");
        OnPlayerDeath?.Invoke();
    }
}
