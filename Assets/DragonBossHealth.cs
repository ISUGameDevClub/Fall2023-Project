using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBossHealth : MonoBehaviour
{
    private SFXController sfxController;
    [SerializeField] private float health;
    [SerializeField] float damage;
    [SerializeField] int reward;

    Animator animator;

    void Start(){
        sfxController = FindObjectOfType<SFXController>();
        animator = GetComponentInChildren<Animator>();
    }

    //detects collison with anything but the player and reverses the movement
    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.GetComponent<PlayerHealth>()){
            GameObject player = other.gameObject;
            player.GetComponent<PlayerHealth>().DamagePlayer(damage,transform.position);
        }
    }

    //method for taking damage
    public void TakeDamage(float damageTaken){
        sfxController.playSound(6);
        health -= damageTaken;
        animator.SetTrigger("Damaged");
        if (health < 0){
            Die();
        }
    }

    void Die() {
        sfxController.playSound(21);
        FindObjectOfType<CurrencyCount>().AddAmount(reward);
        GameManager.wrathDefeated = true;
        if(GameManager.CheckIfAllDefeated())
        {
            FindObjectOfType<LevelLoader>().StartTransition("3FinalCredits");
        }
        else
        {
            FindObjectOfType<LevelLoader>().StartTransition("2LevelSelect");
        }
        Destroy(gameObject);
    }

}
