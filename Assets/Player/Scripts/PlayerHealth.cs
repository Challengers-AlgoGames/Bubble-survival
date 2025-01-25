using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static event Action OnPlayerDeath;

    [Header("Header Setting")]
    public int maxHeart = 3;
    private int currentHeart;

    private HeartVisual heartVisual;

    private void Awake()
    {
        heartVisual = FindAnyObjectByType<HeartVisual>();
    }

    private void Start()
    {
        currentHeart = maxHeart;
    }

    private void Update()
    {
        Debug.Log($"currentHeart : {currentHeart} / {maxHeart}");
    }

    private void TakeDamage()
    {
        if (currentHeart > 0)
        {
            currentHeart--;
            heartVisual.TakeDamage(1);

            if (currentHeart == 0)
            {
                Die();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bubble"))
        {
            Debug.Log("Collision");
            Destroy(collision.gameObject);
            TakeDamage();
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Bubble"))
        {
            Debug.Log("Collision");
            TakeDamage();
        }
    }

    private void Die()
    {
        Debug.Log("Player has died");
        OnPlayerDeath?.Invoke();
    }
}
