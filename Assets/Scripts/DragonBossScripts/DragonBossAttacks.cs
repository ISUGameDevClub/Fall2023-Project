using System.Collections;
using UnityEngine;

public class DragonBossAttacks : MonoBehaviour
{
    //TOMMY: SFX on Wrath Beam, Fireball, swipes, hits, and death.

    private Animator dragonAnimator;
    private float attackTimer;
    private bool isAttacking;
    public GameObject shootPoint;
    public GameObject fastFireball;
    public GameObject slowFireball;
    public float timeBetweenAttacks;
    [Header("Random delay in fireballs from 0 to x seconds.")]
    public float fireballSpawnDelays;
     
    // Start is called before the first frame update
    void Start()
    {
        dragonAnimator = GetComponentInChildren<Animator>();
        attackTimer = timeBetweenAttacks * 2; // Gives the player double the time on spawn to prepare for an attack.
    }

    // Update is called once per frame
    void Update()
    {
        // Will count down attackTimer while not attacking.
        if(attackTimer > 0 && !isAttacking)
        {
            attackTimer -= Time.deltaTime;
        }
        // Will trigger an attack AND reset timer if not attacking.
        if(attackTimer <= 0 && !isAttacking)
        {
            Attack();
            attackTimer = timeBetweenAttacks;
        }
    }

    private void Attack()
    {
        // Generates a random integer to choose attack.
        int randomAttack = Random.Range(1, 5);
        // Will set the animator's "Attack" parameter to the random attack, triggering that animation.
        dragonAnimator.SetInteger("Attack", randomAttack);
        // Sets isAttacking to true to prevent resets.
        isAttacking = true;
    }

    // Method to set attacking to false through animation event.
    // Animation should set attacking false at the end of its animation.
    public void SetAttackingFalse()
    {
        this.isAttacking = false;
        dragonAnimator.SetInteger("Attack", 0);
    }

    //Spawns random fireballs through animation event.
    public IEnumerator SpawnFireballs()
    {
        // Randomly creates five fireballs to spawn.
        GameObject[] fireBallArray = new GameObject[5];
        for(int i = 0; i <= 4; i++)
        {
            int pickFireball = Random.Range(0, 2);
            
            if(pickFireball == 0)
            {
                fireBallArray[i] = fastFireball;
            }
            else
            {
                fireBallArray[i] = slowFireball;
            }
        }

        // Offsets fireball spawns slightly.
        float spawnDelay;
        for (int i = 0; i < 5; i++)
        {
            // Forcibly gets out of this loop if the enemy is done attacking.
            if(isAttacking == false)
            {
                break;
            }
            spawnDelay = Random.Range(0, i);
            Instantiate(fireBallArray[i], shootPoint.transform.position, Quaternion.identity, null);
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
