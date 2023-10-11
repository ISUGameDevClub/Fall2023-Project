using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //[SerializeField]
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float jumpImpulse = 5f;
    [SerializeField] float speed = 2f;
    Transform playerTransform;
    Rigidbody2D rb;
    RaycastHit2D hit;
    bool isGrounded;
    [SerializeField] SpriteRenderer spriteRenderer;

    // Update is called once per frame
    void Start(){
        isGrounded=true;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(rb.velocity.x > 5f){
            rb.velocity = new Vector2(5,rb.velocity.y);
        }
        if(rb.velocity.x < -5f){
            rb.velocity = new Vector2(-5,rb.velocity.y);
        }
        playerTransform = transform;
        LeftMove();
        RightMove();
        Jump();
    }
    void LeftMove()
    {
        if (Input.GetKey("left") )
        {
            rb.AddForce(new Vector2(-speed, 0));
        }
    }
    void RightMove()
    {
        if (Input.GetKey("right") )
        {
            rb.AddForce(new Vector2(speed, 0));
        }
    }
    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            RaycastHit2D hit = Physics2D.Raycast(this.rb.position, Vector2.down, 100.0f, groundLayer);
            Debug.Log(hit.distance.ToString() + " " + hit.collider);

            if(hit.distance < 0.7f){
                isGrounded = true;
            }else{
                isGrounded = false;
            }
            if(isGrounded){
            rb.AddForce(new Vector2(0, jumpImpulse), ForceMode2D.Impulse );
            }
        }
    }
}
