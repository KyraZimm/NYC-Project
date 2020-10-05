using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    
    //movement vars
    private int speed;
    private bool canJump = true;
    private bool isJumping = false;
    private bool isWalking = false;
    private Animator playerAnim;
    private SpriteRenderer playerSprite;
    
    //components
    private Rigidbody2D rb;

    private Vector3 startPos;
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerAnim = gameObject.GetComponent<Animator>();
        playerSprite = gameObject.GetComponent<SpriteRenderer>();

        startPos = gameObject.transform.position;
    }

    void Update()
    {
        //walking controls
        if (Input.GetKey(KeyCode.A))
        {
            speed = -5;

            playerSprite.flipX = true;

            isWalking = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            speed = 5;
            playerSprite.flipX = false;

            isWalking = true;
        }
        else
        {
            speed = 0;
            isWalking = false;
        }
        
        transform.Translate(speed * Time.deltaTime, 0, 0);

        //jump
        if (canJump == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("space pressed");
                rb.AddForce(10 * Vector2.up, ForceMode2D.Impulse);
                canJump = false;
                isJumping = true;
            }
        }
        
        if (isJumping)
        {
            playerAnim.Play("JumpAnim");
        }
        else if (isWalking)
        {
            playerAnim.Play("WalkAnim");
        }
        else
        {
            playerAnim.Play("Idle");
        }

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Platform")
        {
            Debug.Log(rb.velocity);
            if (rb.velocity.y <= 0)
            {
                //connected
                canJump = true;
            }
            
            isJumping = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Barrel")
        {
            playerAnim.transform.position = startPos;
        }
    }
}
