using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ParasiteController : MonoBehaviour
{
    private SFXController sfxController;
    Rigidbody2D rb;
    [SerializeField] private float health;
    [SerializeField] int damage;
    [SerializeField] private int moveSpeed;
    [SerializeField] Vector2 rayCastOffeset = new Vector2(0, -0.6f);
    private bool isGrounded;
    private float nextMoveOp;
    private Vector2 moveDir;
    [SerializeField] float jumpTimer = 2;

    private float jumpLast = 0;
    // Start is called before the first frame update
    void Start()
    {
        sfxController = FindObjectOfType<SFXController>();
        rb = GetComponent<Rigidbody2D>();
        // rb.AddForce(new Vector2(200, 500));
        moveDir = new Vector2(moveSpeed * GetPlayerDir(), 0);
        nextMoveOp = Time.time + 1;
        jumpLast = Time.time + 3;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 raycastOrigin = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin + rayCastOffeset, Vector2.down, 0.2f);
        Debug.DrawRay(raycastOrigin + rayCastOffeset, Vector2.down * 0.2f, Color.red);
        if (nextMoveOp < Time.time) {
            moveDir = new Vector2(moveSpeed * GetPlayerDir(), 0);
            nextMoveOp = Time.time + 1;
        }
        if (hit.collider){
            rb.AddForce(moveDir);
            if (jumpLast < Time.time) {
                jumpLast = Time.time + jumpTimer;
                rb.AddForce(new Vector2(0, 500));
            }
        }
    }

    private int GetPlayerDir() {
        Transform playerLocation = GameObject.FindGameObjectWithTag("Player").transform;
        if (transform.position.x < playerLocation.position.x) {
            // Player is on the right side
            return 1;
        } else {
            // Player is on the left side
            return -1;
        }
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.GetComponent<PlayerHealth>()){
            GameObject player = other.gameObject;
            player.GetComponent<PlayerHealth>().DamagePlayer(damage,transform.position);
        }
    }

    public void TakeDamage(float damageTaken){
        sfxController.playSound(22);
        health -= damageTaken;
        if (health < 0){
            Die();
        }
    }

    void Die(){
        sfxController.playSound(22);
        Destroy(gameObject);
    }
}
