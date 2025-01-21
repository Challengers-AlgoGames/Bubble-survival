using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMouvement : MonoBehaviour
{
    private Rigidbody2D rb;
    [Header("Mouvement setting")]
    public float moveSpeed;
    public float deceleration = 5f;

    private Vector2 moveDirection;
    private Vector2 currentVelocity;
    private bool isSliding = false;

    public InputActionReference move;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        // Entrée utilisateur
        moveDirection = move.action.ReadValue<Vector2>();

        if (moveDirection != Vector2.zero)
        {
            isSliding = false;
            currentVelocity = moveDirection.normalized * moveSpeed;
        }
        else if (!isSliding)
        {
            isSliding = true;
        }
    }

    private void FixedUpdate()
    {
        if (isSliding)
        {
            currentVelocity = Vector2.Lerp(currentVelocity, Vector2.zero, deceleration * Time.fixedDeltaTime);
        }
        rb.linearVelocity = currentVelocity;
    }
}
