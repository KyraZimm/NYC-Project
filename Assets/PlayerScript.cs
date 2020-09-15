using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    
    //movement vars
    private int speed;
    private bool canJump = true;
    private Animator playerAnim;
    private SpriteRenderer playerSprite;
    
    //components
    private Rigidbody2D rb;
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerAnim = gameObject.GetComponent<Animator>();
        playerSprite = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //walking controls
        if (Input.GetKey(KeyCode.A))
        {
            speed = -5;

            playerSprite.flipX = true;
            playerAnim.Play("WalkAnim");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            speed = 5;
            playerSprite.flipX = false;
            playerAnim.Play("WalkAnim");
        }
        else
        {
            speed = 0;
            playerAnim.Play("Idle");
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
            }
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
        }
    }
}
