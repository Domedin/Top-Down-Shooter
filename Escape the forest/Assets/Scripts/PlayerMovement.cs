using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //movement variables
    private float moveSpeed = 4f;
    private Rigidbody2D rb;
    Vector2 movement;

    //dash variables
    private float activeMoveSpeed;
    private float dashSpeed = 25f;
    private float dashLength = 0.2f;
    private float dashCoolDown = 3f;
    private float dashCounter;
    private float dashCoolCounter;

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
    private void dash()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && dashCoolCounter <= 0 && dashCounter <= 0)
        {
            
            
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
                Debug.Log("Detecting space");
            }
        }
        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCoolDown;
            }
        }

        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }
    void Update()
    {
        Move();
        dash();
    }
    private void FixedUpdate()
    {
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        rb.velocity = movement * activeMoveSpeed;
    }
}
