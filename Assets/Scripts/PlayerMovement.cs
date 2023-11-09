using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //move all of this to a fixed update so that physics works properly, this may fix the jumping issue, otherwise it allows all jumping to be evenly distributed over 60 frames rather than being different at 20fps and 120fps
    //[SerializeField]
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float jumpImpulse = 5f;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float jumpGScale = 1f;
    [SerializeField] float fallingGScale = 2.5f;
    [SerializeField] float gScaleIncrement = .01f;
    float tempGscale;
    bool knocked;
    
    Vector3 lastGroundPosition;
    Transform playerTransform;
    Rigidbody2D rb;
    RaycastHit2D hit;
    bool isGrounded;
    [SerializeField] SpriteRenderer spriteRenderer;
    bool colLadder;
    bool isMoving;

    bool jumping;

    //Animator Usage
    Animator movementAnims;

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.layer==7){
         colLadder = true;
        }
    }
    void OnTriggerExit2D(Collider2D col){
        if(col.gameObject.layer==7){
         colLadder = false;
        }
    }
    void Start(){
        tempGscale = jumpGScale;
        jumping=false;
        isGrounded=true;
        rb = GetComponent<Rigidbody2D>();
        movementAnims = GetComponent<Animator>();
    }
    void Update()
    {
        if(rb.velocity.x>0){
            spriteRenderer.flipX=false;
        }else if(rb.velocity.x<0){
            spriteRenderer.flipX=true;
        }
        if(rb.velocity.x > 5f){
            rb.velocity = new Vector2(5,rb.velocity.y);
        }
        if(rb.velocity.x < -5f){
            rb.velocity = new Vector2(-5,rb.velocity.y);
        }
        playerTransform = transform;
        if(!knocked){
            Move();
            Jump();
            Ladder();
        }
        //gets last ground position
        if(rb.velocity.y<=0f&&!jumping)isGrounded=false;
        if(isGrounded)lastGroundPosition = transform.position;
        //Animation Bool
        movementAnims.SetBool("Walking", isMoving);
    }
    public void SetKnocked(bool knocked){
        this.knocked=knocked;
    }
    public bool GetKnocked(){
        return knocked;
    }
    public Vector3 GetLastGroundedPosition(){
        return lastGroundPosition;
    }
    public float GetSpeed()
    {
        return moveSpeed;
    }

    public void SetSpeed(float i)
    {
        moveSpeed = i;
    }
    void Move()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"),0,0);
        movementAnims.SetFloat("WalkingSpeed",Mathf.Abs(Input.GetAxis("Horizontal")));
        if(moveDirection.x != 0) {
            isMoving = true;
        }
        else {
            isMoving = false;
        }

        rb.AddForce(moveDirection * moveSpeed);
    }
    void Jump()
    {
        if(Input.GetKey(KeyCode.Space)){
            jumpGScale = Mathf.Lerp(jumpGScale,fallingGScale,gScaleIncrement*Time.deltaTime);
            rb.gravityScale=jumpGScale;
        }else{
            jumpGScale = tempGscale;
            rb.gravityScale=fallingGScale;
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            RaycastHit2D hit = Physics2D.Raycast(this.rb.position, Vector2.down, 100.0f, groundLayer);
            if(hit.distance < 0.2f){
                isGrounded = true;
            }else{
                isGrounded = false;
            }
            if(isGrounded){
            jumping=true;
            rb.AddForce(new Vector2(0, jumpImpulse), ForceMode2D.Impulse );
            }
        }
    }
    void Ladder(){
        if(colLadder&&Input.GetKeyDown(KeyCode.UpArrow)){
            // You cannot directly set the values in the position attribute, you have to set the position attribute to a vector 3 to set the x, I commented it out so we can compile for pushing
            //rb.transform.position.x = Ladder.transform.position.x; 
            rb.velocity = new Vector2(0,5);
        }
    }
    
}
