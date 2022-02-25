using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //movement variables
    private float moveSpeed = 4f;
    private Rigidbody2D rb;
    Vector2 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
