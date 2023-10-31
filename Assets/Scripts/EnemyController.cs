using System;
using TMPro;
using UnityEngine;


public class EnemyController : MonoBehaviour{
    //Goomba enemy should walk through the player and we should be able to use this script for all enemies.
    [SerializeField] private int health;
    [SerializeField] int damage;
    [SerializeField] private int moveSpeed;

    [SerializeField] SpriteRenderer sprite;

    Rigidbody2D rb;

    [SerializeField] enemySelection es;
    private Boolean direction;
    public Boolean getDirection(){
        return direction;
    }

    private enum enemySelection {
        enemy1,
        enemy2,
        enemy3
    };

    Animator animator;
    Physics2D physics;

    void Start(){
        direction = true;
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
        if (other.gameObject.tag == "Wall" && direction) {
            direction = false;
        }
        else if (other.gameObject.tag == "Wall" && !direction){
            direction = true;
        }
        if(other.gameObject.GetComponent<PlayerHealth>()){
            GameObject player = other.gameObject;
            player.GetComponent<PlayerHealth>().DamagePlayer(damage);
        }
    }

    private void updateEnemy1(){
        if (direction){
            rb.AddForce(Vector2.right * moveSpeed);
            this.sprite.flipY = false;
        }
        else{
            rb.AddForce(Vector2.left * moveSpeed);
            this.sprite.flipY = true;
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
