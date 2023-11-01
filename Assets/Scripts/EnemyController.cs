using System;
using TMPro;
using UnityEngine;


public class EnemyController : MonoBehaviour{
    [SerializeField] private int health;
    [SerializeField] int damage;
    [SerializeField] private int moveSpeed;

    [SerializeField] SpriteRenderer sprite;

    Rigidbody2D rb;

    [SerializeField] enemySelection es;
    private bool direction;
    public bool getDirection(){
        return direction;
    }

    private enum enemySelection {
        enemy1,
        enemy2,
        enemy3
    };

    Animator animator;

    void Start(){
        direction = true;

        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        switch (es) {
            case enemySelection.enemy1:{
                updateEnemy1();
                break;
            }
            case enemySelection.enemy2:{

                break;
            }
            case enemySelection.enemy3:{

                break;
            }
        }
    }

    //detects collison with anything but the player and reverses the movement
    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.layer==10) {
            direction=!direction;
        }
        if(other.gameObject.GetComponent<PlayerHealth>()){
            GameObject player = other.gameObject;
            player.GetComponent<PlayerHealth>().DamagePlayer(damage,transform.position);
        }
    }

    private void updateEnemy1(){
        if (direction){
            rb.MovePosition(rb.position+(Vector2.right * moveSpeed*Time.fixedDeltaTime));
            this.sprite.flipX = true;
        }
        else if (!direction){
            rb.MovePosition(rb.position+(Vector2.left * moveSpeed*Time.fixedDeltaTime));
            this.sprite.flipX = false;
        }
    }

    //method for taking damage
    public void TakeDamage(int damageTaken){
        health -= damageTaken;
        animator.SetBool("Attacked", true);
        if (health < 0){
            Die();
        }
    }
    void Die(){
        Destroy(gameObject);
    }
}
