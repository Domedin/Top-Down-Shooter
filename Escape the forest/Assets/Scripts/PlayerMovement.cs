using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float moveSpeed = 4f;
    public static float playerHealth = 1f;
    [SerializeField] private Rigidbody2D rb;
    Vector2 movement;

    private void Start()
    {
        playerHealth = 1f;
    }
    private void Move()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = Vector2.ClampMagnitude(movement, 1);
    }
    void Update()
    {
        Move();
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
