using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;       // Movement speed of the player
    public float friction = 0.9f;      // Friction to apply when no input is given (lower = more slippery)
    
    
    private Vector2 movement;          // 2D movement vector
    private Rigidbody2D rb;            // Reference to the player's Rigidbody2D
    public GameObject currentHolding;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
       
    }

    void FixedUpdate()
    {

        if (movement.magnitude > 0)
        {
            SFXManager.instance.StartPlayerWalkSound();
            rb.velocity = movement.normalized * moveSpeed;
        }
        else
        {
            SFXManager.instance.StopPlayerWalkSound();
            rb.velocity = rb.velocity * friction;
        }
    }
}
