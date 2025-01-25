using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHealth : MonoBehaviour
{
    [Header("Header Setting")]
    public int maxHeart = 3;
    private int currentHeart;

<<<<<<< Updated upstream
    public delegate void HealthCHanged(int currentHeart, int maxHeart);
    public event HealthCHanged OnHealthChanged;
=======

>>>>>>> Stashed changes
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
    private void Update()
    {
<<<<<<< Updated upstream
        if (Input.GetKeyDown(KeyCode.F)) // Utilisation de KeyCode pour plus de clarté
        {
            if (heartVisual != null)
=======
        Debug.Log($"currentHeart : {currentHeart} / {maxHeart}");
    }

    private void TakeDamage()
    {
        if (currentHeart > 0)
        {
            currentHeart--;
            heartVisual.TakeDamage(1);
            if (currentHeart == 0)
>>>>>>> Stashed changes
            {
                heartVisual.Heal(1);
            }
            else
            {
                Debug.LogError("heartVisual is not initialized!");
            }
        }
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
    }
}
