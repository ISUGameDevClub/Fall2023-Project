using System;
using TMPro;
using UnityEngine;


public class EnemyController : MonoBehaviour{
    //TOMMY: Enemy hit and death can go here

    [SerializeField] private float health;
    [SerializeField] float damage;
    [SerializeField] private int moveSpeed;
    [SerializeField] int reward;

    private GameObject player;
    public GameObject EnemyExplosion;

    [SerializeField] SpriteRenderer sprite;
    Rigidbody2D rb;

    public bool takeExtraDamage = false;

    [SerializeField] enemySelection es;
    private bool direction;
    public bool getDirection(){
        return direction;
    }

    public enum enemySelection {
        enemy1,
        enemy2,
        enemy3
    };

    Animator animator;

    void Start(){
        direction = true;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    void Update(){
        switch (es) {
            case enemySelection.enemy1:{
                updateEnemy1();
                break;
            }
            case enemySelection.enemy2:{
                updateEnemy1();
                break;
            }
            case enemySelection.enemy3:{

                break;
            }
        }
    }

    //detects collison with anything but the player and reverses the movement
    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.layer==10 || other.gameObject.layer == 8) {
            direction=!direction;
        }
        if(other.gameObject.GetComponent<PlayerHealth>()){
            GameObject player = other.gameObject;
            if (es == enemySelection.enemy2)
            {
                Die();
            }
            else
            {
                player.GetComponent<PlayerHealth>().DamagePlayer(damage, transform.position);
            }
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
    public void TakeDamage(float damageTaken) {
        if (takeExtraDamage)
        {
            damageTaken *= 2;
        }
        health -= damageTaken;
        animator.SetTrigger("Hurt");
        if (health < 0){
            Die();
        }
    }



    void Die(){
        FindObjectOfType<CurrencyCount>().AddAmount(reward);
        if (es == enemySelection.enemy2)
        {
            FindObjectOfType<SFXController>().playSound(8);
            Instantiate(EnemyExplosion, transform.position, Quaternion.identity, null);
        }
        Destroy(gameObject);
    }
}
