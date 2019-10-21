using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Adjustable Player Variables
    public float playerSpeed;
    public float jumpPower;
    public float extraJumps;

    // Movement Variables
    private float moveInput;
    private bool facingRight;
    private float jumpCharges;

    // Component or Object Variables
    private Rigidbody2D rb;
    private bool isGrounded;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private bool isDead=false;

    // Artifical Gravity (TEST, only uncomment if using KINEMATIC mode for rigidBody2D)
    //public float gravity = 10f;

    //TO-DO:
    //pressing left moves player left
    //pressing right moves player right
    //pressing space moves player up

    private void Start()
    {
        jumpCharges = 1+extraJumps;
    Debug.Log(jumpCharges);
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }


    private void FixedUpdate()                              //updates conditions, player sprite, and player velocity
    {
        if (!isDead)
        {
            moveInput = Input.GetAxis("Horizontal");
            //    Debug.Log(jumpCharges);
            rb.velocity = new Vector2(moveInput * playerSpeed, rb.velocity.y);

            if (facingRight == true && moveInput < 0)           //if the character is facing RIGHT -but- the player wants to move LEFT
            {
                Flip();                                         //flip character sprite
            }
            else if (facingRight == false && moveInput > 0)     //otherwise if the character is facing LEFT -but- wants to move RIGHT
            {
                Flip();                                         //flip character sprite
            }
        }
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (isGrounded == true)                             //when the player is on the ground,
        {
            if (extraJumps > 0) //refresh the player's ability to jump
            {
                jumpCharges = extraJumps;
            }
            else
            {
                jumpCharges = 1;
            }                     
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpCharges > 0)     // if the player pressed jump AND has more than 1 total jump
        {
            jumpCharges--;
            rb.velocity = Vector2.up * jumpPower;           //make player jump
        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 playerScale = transform.localScale;
        playerScale.x *= -1;
        transform.localScale = playerScale;
    }

    void MakeDead()
    {
        isDead = true;

    }


}
