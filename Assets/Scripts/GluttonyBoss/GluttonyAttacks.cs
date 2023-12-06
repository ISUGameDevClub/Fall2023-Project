using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GluttonyAttacks : MonoBehaviour
{
    private Animator bossAnimator;
    private float attackTimer;
    private bool isAttacking;
    public float timeBetweenAttacks;
    [SerializeField]
    private GameObject fireball;
    [SerializeField]
    private float fireballYLevel;
    private GluttonyMove GlutMove;
    [SerializeField] GameObject paraEnemy;

    private SpriteRenderer glutSprite;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        bossAnimator = GetComponent<Animator>();
        attackTimer = timeBetweenAttacks * 2; // Gives the player double the time on spawn to prepare for an attack.
        GlutMove = transform.parent.gameObject.GetComponent<GluttonyMove>();
        glutSprite = GetComponentInChildren<SpriteRenderer>();
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //Sprite Flip!
        if (player.transform.position.x > transform.position.x)
        {
            glutSprite.flipX = true;
        }
        else
        {
            glutSprite.flipX = false;
        }

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
        //Calculate x distance from player
        float xDistanceFromPlayer = 
            Mathf.Abs(transform.position.x - player.transform.position.x);
        float yDistanceFromPlayer = 
            Mathf.Abs(transform.position.y - player.transform.position.y);
        // Generates a random integer to choose attack.
        int randomAttack = 0;
        if (xDistanceFromPlayer >= 4)
        {
            randomAttack = Random.Range(1, 3) * 2;
        }
        else
        {
            if (yDistanceFromPlayer > 2.5)
            {
                randomAttack = Random.Range(1, 3);
            }
            else
            {
                randomAttack = Random.Range(1, 4);
            }
        }
        // Will set the animator's "Attack" parameter to the random attack, triggering that animation.
        bossAnimator.SetInteger("Attack", randomAttack);
        // Sets isAttacking to true to prevent resets.
        isAttacking = true;
    }

    public void SetAttackingFalse()
    {
        this.isAttacking = false;
        bossAnimator.SetInteger("Attack", 0);
    }

    public void ChargePlayer(){
        GlutMove.ChargePlayer();
    }

    public void ThrowPara() {
        Vector3 slightlyAbove = gameObject.transform.position + new Vector3(0, 1.5f, 0);
        GameObject newPrefabInstance = Instantiate(paraEnemy, slightlyAbove, Quaternion.identity);
    }

    public void FireAttackBall() {
        Transform playerLocation = GameObject.FindGameObjectWithTag("Player").transform;
        float playerTargetX = playerLocation.position.x;
        float playerTargetY = playerLocation.position.y;
        GameObject newPrefabInstance = Instantiate(fireball, gameObject.transform.position, Quaternion.identity);
        float defaultArcHeight = newPrefabInstance.GetComponent<GluttonyProj>().arcHeight;
        // defaultArcHeight = CalArcHeightOnDistance(Vector2.Distance(transform.position, playerLocation.position));
        if (fireballYLevel < playerLocation.position.y) {
            if (transform.position.x < playerLocation.position.x) {
                // Player is on the right side
                playerTargetX = playerTargetX + playerTargetY;
            } else {
                // Player is on the left side
                playerTargetX = playerTargetX - playerTargetY;
            }
        }
        //newPrefabInstance.GetComponent<GluttonyProj>().targetPosition = new Vector2(playerTargetX, -1);
        //newPrefabInstance = Instantiate(fireball, gameObject.transform.position, Quaternion.identity);
        newPrefabInstance.GetComponent<GluttonyProj>().targetPosition = new Vector2(playerTargetX + 5, -1);
        newPrefabInstance.GetComponent<GluttonyProj>().arcHeight = defaultArcHeight - 2;
        newPrefabInstance = Instantiate(fireball, gameObject.transform.position, Quaternion.identity);
        newPrefabInstance.GetComponent<GluttonyProj>().targetPosition = new Vector2(playerTargetX - 5, -1);
        newPrefabInstance.GetComponent<GluttonyProj>().arcHeight = defaultArcHeight + 2;
    }

    private float CalArcHeightOnDistance(float distance){
        float minDistance = 1;
        float maxDistance = 10;
        float minHeight = 1;
        float maxHeight = 5;
        distance = Mathf.Clamp(distance, minDistance, maxDistance);

        // Calculate damage using Mathf.Lerp.
        float t = (distance - minDistance) / (maxDistance - minDistance);
        float finalHeight = Mathf.Lerp(maxHeight, minHeight, t);

        return finalHeight;
    }
}
