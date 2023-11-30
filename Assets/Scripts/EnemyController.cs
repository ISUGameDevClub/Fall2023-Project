using System;
using TMPro;
using UnityEngine;


public class EnemyController : MonoBehaviour{
    [SerializeField] private int health;
    [SerializeField] int damage;
    [SerializeField] private int moveSpeed;
    [SerializeField] int reward;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject weapon;
    //hi
    [SerializeField] SpriteRenderer sprite;
    GameObject currencyManager;
    Rigidbody2D rb;

    [SerializeField] enemySelection es;
    [SerializeField] private bool direction;
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
        currencyManager = GameObject.Find("CurrencyManager");
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        DetectGround();
    }
    private void DetectGround()
    {
        LayerMask enemyLayer = gameObject.layer;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right+Vector2.down,1f,12);
        //Debug.DrawRay(transform.position, Vector2.right + Vector2.down,Color.red,.3f);
        if (hit.collider == null)
        {
            Debug.Log("No Ground");
            direction = !direction;
        }
    }
    void FixedUpdate(){
        switch (es) {
            case enemySelection.enemy1:{
                updateEnemy1();
                break;
            }
            case enemySelection.enemy2:{
                updateEnemy2();
                break;
            }
            case enemySelection.enemy3:{

                break;
            }
        }
    }

    //detects collison with anything but the player and reverses the movement
    private void OnCollisionEnter2D(Collision2D other){
        //if (other.gameObject.layer==10 || other.gameObject.layer == 8) {
        //    direction=!direction;
        //}
        if(other.gameObject.GetComponent<PlayerHealth>()){
            GameObject player = other.gameObject;
            switch (es)
            {
                
                case enemySelection.enemy1:
                    {
                        player.GetComponent<PlayerHealth>().DamagePlayer(damage, transform.position);
                        break;
                    }
                case enemySelection.enemy2:
                    {
                        TakeDamage(100);
                        break;
                    }
                case enemySelection.enemy3:
                    {
                        player.GetComponent<PlayerHealth>().DamagePlayer(damage, transform.position);
                        break;
                    }
                    
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

    private void updateEnemy2()
    {
        if (direction)
        {
            rb.MovePosition(rb.position + (Vector2.right * moveSpeed * Time.fixedDeltaTime));
            this.sprite.flipX = true;
        }
        else if (!direction)
        {
            rb.MovePosition(rb.position + (Vector2.left * moveSpeed * Time.fixedDeltaTime));
            this.sprite.flipX = false;
        }
    }
    //method for taking damage
    public void TakeDamage(int damageTaken){
        switch (es)
        {
            case enemySelection.enemy2:
                {
                    GameObject clone = Instantiate(bullet, weapon.transform.position, transform.rotation);
                    clone.GetComponent<EnemyBulletController>().FireBullet(es);
                    Destroy(gameObject);
                    break;
                }
            default:
                {
                    health -= damageTaken;
                    animator.SetBool("Attacked", true);
                    if (health < 0)
                    {
                        Die();
                    }
                    break;
                }
        }

    }
    void Die(){
        currencyManager.GetComponent<currencyCount>().addAmount(reward);
        Destroy(gameObject);
    }
}
