using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float JumpHeight;
    [SerializeField] SpriteRenderer spriteRenderer;
    Transform playerTransform;
    
    void Start()
    {
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
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            transform.position = new Vector2(transform.position.x + Input.GetAxis("Horizontal") * speed * Time.deltaTime, transform.position.y);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + Input.GetAxis("Vertical") * JumpHeight);
            Debug.Log("Jump Key presed");
        }
    }
    //jump.

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
