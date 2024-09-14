using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool activeMovement = false;

    public float moveSpeed = 5f;          // Movement speed of the player
    public float friction = 0.9f;         // Friction to apply when no input is given (lower = more slippery)
    public float rotationSpeed = 10f;     // Speed at which the player rotates towards the movement direction
    [SerializeField] private Transform PlayerRotation;
    [SerializeField] private SpriteRenderer ItemSprite;

    private Vector2 movement;             // 2D movement vector
    private Rigidbody2D rb;               // Reference to the player's Rigidbody2D
    private ItemData currentHolding;

    public void SetItem(ItemData item)
    {
        currentHolding = item;
        ItemSprite.transform.parent.gameObject.SetActive(true);
        ItemSprite.sprite = item.ItemSprite;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (activeMovement)
        {
            // Get input for movement
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            // Rotate player to face the movement direction smoothly if moving
            if (movement.magnitude > 0)
            {
                RotatePlayerTowardsMovementDirection();
            }
        }
    }

    void FixedUpdate()
    {
        if (activeMovement)
        {
            if (movement.magnitude > 0)
            {
                SFXManager.instance.StartPlayerWalkSound();
                rb.velocity = movement.normalized * moveSpeed;
            }
            else
            {
                SFXManager.instance.StopPlayerWalkSound();
                rb.velocity = rb.velocity * friction;  // Apply friction when no input is given
            }
        }
    }

    // Method to smoothly rotate the player to face the movement direction
    void RotatePlayerTowardsMovementDirection()
    {
        // Calculate the angle from the movement direction
        float targetAngle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg; // Convert to degrees

        // Add 90 degrees to the angle to correct the default forward direction (right) to face "up"
        targetAngle -= 90f;

        // Get the current rotation (z-axis) of the player
        float currentAngle = PlayerRotation.rotation.eulerAngles.z;

        // Smoothly interpolate between the current angle and the target angle
        float smoothedAngle = Mathf.LerpAngle(currentAngle, targetAngle, Time.deltaTime * rotationSpeed);

        // Apply the smooth rotation to the player's transform
        PlayerRotation.rotation = Quaternion.Euler(new Vector3(0, 0, smoothedAngle));
    }


    public void SetActiavtion(bool actiavtion)
    {
        activeMovement = actiavtion;
    }

    public bool CheckItenID(int id)
    {
        if(currentHolding != null)
        {
            if (id == currentHolding.ItemID)
            {
                currentHolding = null;
                ItemSprite.sprite = null;
                ItemSprite.transform.parent.gameObject.SetActive(false);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            Debug.Log("No Item in Hand");
            return false;
        }
    }
}
