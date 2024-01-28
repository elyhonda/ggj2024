using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class Movement : MonoBehaviour 
{
    public Animator animator;
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public string playerId;
    private Rigidbody2D rb;
    private bool isGrounded;
    private float groundCheckRadius = 0.9f;
    public LayerMask groundLayer;
    private bool m_isAxisInUse = false;
    private GameManager gameManager;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        float moveInput = Input.GetAxisRaw("Horizontal" + playerId);
        Vector2 moveVelocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        rb.velocity = moveVelocity;
        animator.SetFloat("Speed", Mathf.Abs(moveInput));
        if(Input.GetAxisRaw("Horizontal" + playerId) > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        else if(Input.GetAxisRaw("Horizontal" + playerId) < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    void Jump()
    {
        if( Input.GetAxisRaw("Jump" + playerId) != 0)
        {
            if(m_isAxisInUse == false)
            {
                // Call your event function here.
                m_isAxisInUse = true;
            }
        }
        if( Input.GetAxisRaw("Jump" + playerId) <= 0)
        {
            m_isAxisInUse = false;
 
        }    
        isGrounded = Physics2D.OverlapCircle(transform.position, groundCheckRadius, groundLayer);

        if (isGrounded && m_isAxisInUse)
        {
            animator.SetBool("Jump", true);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        else if(!isGrounded)
        {
            animator.SetBool("Jump", false);
        }
    }  
    public void Death()
    {
        if(gameManager != null)
        {
            switch (int.Parse(playerId))
            {
                case 1:
                    gameManager.isPlayer1Dead = true;
                    gameManager.PlayerDead();
                    Destroy(this.gameObject);
                    break;
                case 2:
                    gameManager.isPlayer2Dead = true;
                    gameManager.PlayerDead();
                    Destroy(this.gameObject);
                    break;
                case 3:
                    gameManager.isPlayer3Dead = true;
                    gameManager.PlayerDead();
                    Destroy(this.gameObject);
                    break;
                case 4:
                    gameManager.isPlayer4Dead = true;
                    gameManager.PlayerDead();
                    Destroy(this.gameObject);
                    break;
            }
        }  
    }
}  
