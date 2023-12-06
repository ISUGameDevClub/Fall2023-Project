using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreedBoss : MonoBehaviour
{
    private Animator greedAnimator;
    private float attackTimer;
    private bool isAttacking;
    public float timeBetweenAttacks;

    public GameObject shootPoint;
    public GameObject cardProjectile;
    public GameObject slotMachine;

    //Health
    public float health;
    public float damage;
    public int reward;
    

    // Start is called before the first frame update
    void Start()
    {
        greedAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(attackTimer > 0 && !isAttacking)
        {
            attackTimer -= Time.deltaTime;
        }
        if(attackTimer <= 0 && !isAttacking)
        {
            Attack();
            attackTimer = timeBetweenAttacks;
        }
    }

    private void Attack()
    {
        isAttacking = true;
        int randomAttack = Random.Range(1, 4);
        if(randomAttack == 1)
        {
            greedAnimator.SetInteger("Attack", randomAttack);
        }
        else if(randomAttack == 2)
        {
            greedAnimator.SetInteger("Attack", randomAttack);
        }
        else if(randomAttack == 3)
        {
            if (slotMachine.GetComponent<SlotMachine>().isSpinning == true)
            {
                int otherAttack = Random.Range(1, 3);
                greedAnimator.SetInteger("Attack", otherAttack);
            }
            else
            {
                slotMachine.GetComponent<SlotMachine>().SpinSlots();
                isAttacking = false;
            }
        }
    }



    //Hurt player if touching boss.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerHealth>())
        {
            GameObject player = collision.gameObject;
            player.GetComponent<PlayerHealth>().DamagePlayer(damage, transform.position);
        }
    }


    //Methods for damage and dying.
    public void TakeDamage(float damageTaken)
    {
        health -= damageTaken;
        greedAnimator.SetTrigger("Damaged");
        if (health < 0)
        {
            Die();
        }
    }

    void Die()
    {
        FindObjectOfType<CurrencyCount>().AddAmount(reward);
        GameManager.greedDefeated = true;
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
