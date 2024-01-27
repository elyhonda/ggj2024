using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class Movement : MonoBehaviour 
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public string playerId;
    public int life = 1;

    private Rigidbody2D rb;
    private bool isGrounded;
    private float groundCheckRadius = 1f;
    public LayerMask groundLayer;
    private bool m_isAxisInUse = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    
    public void Death()
    {
        gameObject.SetActive(false);
    }
}
