using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GluttonyHealth : MonoBehaviour
{
    [Header("SFX")]
    private SFXController sfxController;

    [SerializeField] private float health;
    [SerializeField] float collisionDamage;
    [SerializeField] int reward;

    Rigidbody2D rb;
    Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sfxController = FindObjectOfType<SFXController>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<PlayerHealth>())
        {
            GameObject player = other.gameObject;
            player.GetComponent<PlayerHealth>().DamagePlayer(collisionDamage, transform.position);
        }
    }

    //method for taking damage
    public void TakeDamage(float damageTaken)
    {
        health -= damageTaken;
        animator.SetTrigger("Hurt");
        sfxController.playSound(6);
        if (health < 0)
        {
            Die();
        }
    }

    void Die()
    {
        sfxController.playSound(21);
        FindObjectOfType<CurrencyCount>().AddAmount(reward);
        GameManager.gluttonyDefeated = true;
        if (GameManager.CheckIfAllDefeated())
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
