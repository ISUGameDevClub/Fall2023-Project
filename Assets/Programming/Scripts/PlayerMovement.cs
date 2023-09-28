using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 1;
    Transform playerTransform;
    Rigidbody2D rb;
    bool isGrounded;

    // Update is called once per frame
    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        playerTransform = transform;
        LeftRightMove();
        Jump();
    }
    void LeftRightMove()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.position = new Vector2(transform.position.x + (Input.GetAxis("Horizontal") * speed) / 2, transform.position.y);
        }
    }
    void Jump()
    {

        if(isGrounded && Input.GetKeyDown("space")){
            rb.velocity = new Vector2(0.0f,5.0f);
        }


    }
}
