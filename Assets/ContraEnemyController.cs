using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemyController;

public class ContraEnemyController : MonoBehaviour
{
    private SFXController sfxController;

    private bool playerNear = false;
    public float playerNearDistance = 10f;

    [SerializeField] LayerMask groundLayer;
    private float jumpTimer;
    private bool isGrounded = true;

    public float jumpTimeMax;
    public float jumpForce = 10f;

    [SerializeField] private float health;
    [SerializeField] float damage;
    [SerializeField] private int moveSpeed;
    [SerializeField] int reward;

    [SerializeField] SpriteRenderer sprite;
    Rigidbody2D rb;

    public bool takeExtraDamage = false;

    private bool movingLeft;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        movingLeft = true;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sfxController = FindObjectOfType<SFXController>();

        jumpTimer = jumpTimeMax;
        playerNear = false;
    }

    private void Update()
    {
        //Checks if player is near, never unsets after.
        if (Vector2.Distance(transform.position, 
            FindObjectOfType<PlayerMovement>().transform.position) < playerNearDistance)
        {
            playerNear = true;
        }

        if (playerNear)
        {
            if (jumpTimer > 0)
            {
                jumpTimer -= Time.deltaTime;
            }
            else if (jumpTimer <= 0)
            {
                jumpTimer = Random.Range(.5f, jumpTimeMax);
                if (isGrounded)
                {
                    rb.AddForce(new Vector2(moveSpeed, jumpForce), ForceMode2D.Impulse);
                }
            }

            //Check if grounded
            RaycastHit2D hit = Physics2D.Raycast(this.rb.position, Vector2.down, 100.0f, groundLayer);
            Debug.DrawRay(this.rb.position, Vector2.down * 100.0f, Color.red);
            if (hit.distance < 0.2f)
            {
                isGrounded = true;
            }
            else if (hit.distance > 0.2f)
            {
                isGrounded = false;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerNear)
        {
            //Run towards left infinitely basically
            if (movingLeft)
            {
                rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            }
            else if (!movingLeft)
            {
                rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
            }
        }
    }

    //method for taking damage
    public void TakeDamage(float damageTaken)
    {
        sfxController.playSound(6);
        if (takeExtraDamage)
        {
            damageTaken *= 2;
        }
        health -= damageTaken;
        animator.SetTrigger("Hurt");
        if (health < 0)
        {
            Die();
        }
    }

    void Die()
    {
        sfxController.playSound(7);
        FindObjectOfType<CurrencyCount>().AddAmount(reward);
        Destroy(gameObject);
    }

    //detects collison with anything but the player and reverses the movement
    private void OnCollisionEnter2D(Collision2D other)
    {
        //if (other.gameObject.layer == 10 || other.gameObject.layer == 8)
        //{
        //    movingLeft = !movingLeft;
        //    sprite.flipX = !sprite.flipX;
        //}
        if (other.gameObject.GetComponent<PlayerHealth>())
        {
            GameObject player = other.gameObject;
            player.GetComponent<PlayerHealth>().DamagePlayer(damage, transform.position);
        }
    }
}
