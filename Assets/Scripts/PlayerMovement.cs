using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //[SerializeField]
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float jumpImpulse = 5f;
    /*[SerializeField]*/public float moveSpeed = 2f;
    Transform playerTransform;
    Rigidbody2D rb;
    RaycastHit2D hit;
    bool isGrounded;
    [SerializeField] SpriteRenderer spriteRenderer;
    bool colLadder;

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.Layer==7){
         colLadder = true;
        }
    }
    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.Layer==7){
         colLadder = false;
        }
    }
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
        OnTriggerEnter2D(Ladder);
        OnTriggerExit2D(Ladder);
        Ladder();
    }
    float GetSpeed()
    {
        return speed;
    }

    void SetSpeed(float i)
    {
        speed = i;
    }
    void LeftMove()
    {
        if (Input.GetKey("left") )
        {
            rb.AddForce(new Vector2(-moveSpeed, 0));
        }
    }
    void RightMove()
    {
        if (Input.GetKey("right") )
        {
            rb.AddForce(new Vector2(moveSpeed, 0));
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
    void Ladder(){
        if(colLadder&&Input.GetKeyDown(KeyCode.UpArrow)){
            rb.transform.position.x = Ladder.transform.position.x;
            rb.velocity = new Vector2(0,5);
        }
    }
    
}
