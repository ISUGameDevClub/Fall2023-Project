using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool canMove;
    private Rigidbody2D rb;
    public float moveSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        LeftRightMove();
    }
    
    void LeftRightMove()
    {
        Vector2 horizontalInput = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, 0f);
        rb.MovePosition(rb.position + horizontalInput * Time.fixedDeltaTime);
    }
}
