using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //move all of this to a fixed update so that physics works properly, this may fix the jumping issue, otherwise it allows all jumping to be evenly distributed over 60 frames rather than being different at 20fps and 120fps
    //[SerializeField]
    private Vector3 moveDirection;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] float jumpImpulse = 5f;
    [SerializeField] float defaultGravity = 2.5f;
    [SerializeField] float weakGravity = 1.5f;
    bool knocked;
    
    Vector3 lastGroundPosition;
    Rigidbody2D rb;
    bool isGrounded;
    bool colLadder;
    bool isMoving;

    bool jumping;

    //Animator Usage
    Animator movementAnims;
    public SpriteRenderer[] spriteRenderers;

    void Start()
    {
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        jumping = false;
        isGrounded = true;
        rb = GetComponent<Rigidbody2D>();
        movementAnims = GetComponent<Animator>();
    }
    void Update()
    {
        FlipSprite();

        //Ground Movement
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0); //In update to ensure consistent input.
        if (moveDirection.x != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if (!knocked)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
            if (Input.GetKey(KeyCode.Space) && rb.velocity.y > 0)
            {
                rb.gravityScale = weakGravity;
            }
            else
            {
                rb.gravityScale = defaultGravity;
            }
            Ladder();
        }
        //gets last ground position
        if (rb.velocity.y <= 0f && !jumping) isGrounded = false;
        if (isGrounded) lastGroundPosition = transform.position;
        //Animation Bool
        movementAnims.SetBool("Walking", isMoving);
    }

    private void FixedUpdate()
    {
        if (!knocked)
        {
            Move();
        }
    }

    void Move()
    {
        movementAnims.SetFloat("WalkingSpeed", Mathf.Abs(Input.GetAxis("Horizontal")));
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
    }

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

    public void SetKnocked(bool knocked){
        this.knocked=knocked;
    }
    public bool GetKnocked(){
        return knocked;
    }
    public Vector3 GetLastGroundedPosition(){
        return lastGroundPosition;
    }

    void Jump()
    {
        RaycastHit2D hit = Physics2D.Raycast(this.rb.position , Vector2.down, 100.0f, groundLayer);
        if (hit.distance < 0.2f){
            isGrounded = true;
        }else{
            isGrounded = false;
        }
        if(isGrounded){
            jumping=true;
            rb.AddForce(new Vector2(0, jumpImpulse), ForceMode2D.Impulse);
        }
    }

    private void JumpGravityChange()
    {
        
    }

    void Ladder(){
        if(colLadder&&Input.GetKeyDown(KeyCode.UpArrow)){
            // You cannot directly set the values in the position attribute, you have to set the position attribute to a vector 3 to set the x, I commented it out so we can compile for pushing
            //rb.transform.position.x = Ladder.transform.position.x; 
            rb.velocity = new Vector2(0,5);
        }
    }

    void FlipSprite()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            for(int i = 0; i < spriteRenderers.Length; i++)
            {
                spriteRenderers[i].flipX = false;
            }
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            for (int i = 0; i < spriteRenderers.Length; i++)
            {
                spriteRenderers[i].flipX = true;
            }
        }
    }

    public float GetSpeed()
    {
        return moveSpeed;
    }

    public void SetSpeed(float i)
    {
        moveSpeed = i;
    }

    void Dash()
    {

    }
}
