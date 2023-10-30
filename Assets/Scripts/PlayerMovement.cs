using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //move all of this to a fixed update so that physics works properly, this may fix the jumping issue, otherwise it allows all jumping to be evenly distributed over 60 frames rather than being different at 20fps and 120fps
    //[SerializeField]
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float jumpImpulse = 5f;
    [SerializeField] float moveSpeed = 2f;
    Transform playerTransform;
    Rigidbody2D rb;
    RaycastHit2D hit;
    bool isGrounded;
    [SerializeField] SpriteRenderer spriteRenderer;
    bool colLadder;
    bool isMoving;

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
        isGrounded=true;
        rb = GetComponent<Rigidbody2D>();

        movementAnims = GetComponent<Animator>();
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
        Move();
        Jump();
        Ladder();

        //Animation Bool
        movementAnims.SetBool("Walking", isMoving);
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
            // You cannot directly set the values in the position attribute, you have to set the position attribute to a vector 3 to set the x, I commented it out so we can compile for pushing
            //rb.transform.position.x = Ladder.transform.position.x; 
            rb.velocity = new Vector2(0,5);
        }
    }
    
}
