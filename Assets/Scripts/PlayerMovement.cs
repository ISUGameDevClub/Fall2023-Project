using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 1;
    Transform playerTransform;
    Rigidbody2D rb;
    bool isGrounded;
    SpriteRenderer spriteRenderer;

    // Update is called once per frame
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        playerTransform = transform;
        LeftRightMove();
        Jump();
        FlipSprite();
    }
    void LeftRightMove()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.position = new Vector2(transform.position.x + (Input.GetAxis("Horizontal") * moveSpeed) / 2, transform.position.y);
        }
    }
    void Jump()
    {

        if(isGrounded && Input.GetKeyDown("space")){
            rb.velocity = new Vector2(0.0f,5.0f);
        }


    }
    void FlipSprite()
    {
        if(Input.GetAxisRaw("Horizontal") < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if(Input.GetAxisRaw("Horizontal") > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
}
