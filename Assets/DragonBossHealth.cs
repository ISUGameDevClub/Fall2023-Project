using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBossHealth : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] int damage;
    [SerializeField] int reward;

    [SerializeField] SpriteRenderer sprite;
    GameObject currencyManager;
    Rigidbody2D rb;
    Animator animator;

    void Start(){
        currencyManager = GameObject.Find("CurrencyManager");
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    //detects collison with anything but the player and reverses the movement
    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.GetComponent<PlayerHealth>()){
            GameObject player = other.gameObject;
            player.GetComponent<PlayerHealth>().DamagePlayer(damage,transform.position);
        }
    }

    //method for taking damage
    public void TakeDamage(int damageTaken){
        health -= damageTaken;
        animator.SetTrigger("Damaged");
        if (health < 0){
            Die();
        }
    }

    void Die(){
        currencyManager.GetComponent<currencyCount>().addAmount(reward);
        FindObjectOfType<LevelLoader>().StartTransition("4DemoEnd"); //TEMPORARY DEMO TRANSITION
        Destroy(gameObject);
    }

}
