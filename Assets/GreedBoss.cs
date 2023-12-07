using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreedBoss : MonoBehaviour
{
    private Animator greedAnimator;
    private float attackTimer;
    public bool isAttacking;
    public float timeBetweenAttacks;

    public GameObject shootPoint;
    public GameObject cardProjectile;
    public float cardSpeed = 10f;
    public GameObject slotMachine;

    //Health
    public float health;
    public float damage;
    public int reward;
    

    // Start is called before the first frame update
    void Start()
    {
        greedAnimator = GetComponentInChildren<Animator>();
        isAttacking = false;
        attackTimer = timeBetweenAttacks;
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
            //Cards
            Debug.Log("Throwing Cards");
            greedAnimator.SetInteger("Attack", randomAttack);
            greedAnimator.SetTrigger("Shoot");
        }
        else if(randomAttack == 2)
        {
            //Dive
            Debug.Log("Diving");
            greedAnimator.SetInteger("Attack", randomAttack);
            greedAnimator.SetTrigger("Shoot");
        }
        else if(randomAttack == 3)
        {
            //Slot Machine
            Debug.Log("Slot Machine");
            if (slotMachine.GetComponent<SlotMachine>().isSpinning == true)
            {
                int otherAttack = Random.Range(1, 3);
                greedAnimator.SetInteger("Attack", otherAttack);
                greedAnimator.SetTrigger("Shoot");
            }
            else
            {
                slotMachine.GetComponent<SlotMachine>().SpinSlots();
                isAttacking = false;
            }
        }
    }

    public void ThrowCard()
    {
        //Instantiate Five Cards at shootpoint, going in 5 directions 
        //We should set the rb.velocity of the cards to go in different directions to the left.
        if(FindObjectOfType<PlayerMovement>().transform.position.x < transform.position.x)
        {
            GameObject card = Instantiate(cardProjectile, shootPoint.transform.position, Quaternion.identity);
            card.GetComponent<Rigidbody2D>().velocity = new Vector2(cardSpeed, 3f);
            card.GetComponent<Rigidbody2D>().rotation = -25f;
            GameObject card2 = Instantiate(cardProjectile, shootPoint.transform.position, Quaternion.identity);
            card2.GetComponent<Rigidbody2D>().velocity = new Vector2(cardSpeed, 1.5f);
            card2.GetComponent<Rigidbody2D>().rotation = -15f;
            GameObject card3 = Instantiate(cardProjectile, shootPoint.transform.position, Quaternion.identity);
            card3.GetComponent<Rigidbody2D>().velocity = new Vector2(cardSpeed, 0);
            card3.GetComponent<Rigidbody2D>().rotation = 0f;
            GameObject card4 = Instantiate(cardProjectile, shootPoint.transform.position, Quaternion.identity);
            card4.GetComponent<Rigidbody2D>().velocity = new Vector2(cardSpeed, -1.5f);
            card4.GetComponent<Rigidbody2D>().rotation = 25f;
        }
        else
        {
            //Opposite
            GameObject card = Instantiate(cardProjectile, shootPoint.transform.position, Quaternion.identity);
            card.GetComponent<Rigidbody2D>().velocity = new Vector2(-cardSpeed, 3f);
            card.GetComponent<Rigidbody2D>().rotation = 25f;
            GameObject card2 = Instantiate(cardProjectile, shootPoint.transform.position, Quaternion.identity);
            card2.GetComponent<Rigidbody2D>().velocity = new Vector2(-cardSpeed, 1.5f);
            card2.GetComponent<Rigidbody2D>().rotation = 15f;
            GameObject card3 = Instantiate(cardProjectile, shootPoint.transform.position, Quaternion.identity);
            card3.GetComponent<Rigidbody2D>().velocity = new Vector2(-cardSpeed, 0);
            card3.GetComponent<Rigidbody2D>().rotation = 0f;
            GameObject card4 = Instantiate(cardProjectile, shootPoint.transform.position, Quaternion.identity);
            card4.GetComponent<Rigidbody2D>().velocity = new Vector2(-cardSpeed, -1.5f);
            card4.GetComponent<Rigidbody2D>().rotation = -25f;
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
