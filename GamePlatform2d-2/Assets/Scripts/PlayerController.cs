﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float jumpForce = 550;
    public Transform groundCheck;
    public float groundRadius = 0.1f;
    public LayerMask groundLayer;

    [SerializeField]
    private float walkSpeed;

    private Rigidbody2D rb;
    private Vector2 newMovement;

    private bool facingRight = true;
    private bool jump = false;
    private bool grounded;
    private bool doubleJump;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void Start()
    {
        
    }

    private void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);

        if(grounded)
        {
            doubleJump = false;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = newMovement;

        if(jump)
        {
            jump = false;
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce);

            if(!doubleJump && !grounded)
            {
                doubleJump = true;
            }
        }
    }

    public void Jump()
    {
        if(grounded || !doubleJump)
        {
            jump = true;
        }
    }

    public void Move(float direction)
    {
        float currentSpeed = walkSpeed;
        newMovement = new Vector2(direction * currentSpeed, rb.velocity.y);

        if(facingRight && direction < 0)
        {
            Flip();
        }
        else if(!facingRight && direction > 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        transform.Rotate(0, 180, 0);
    }
}
