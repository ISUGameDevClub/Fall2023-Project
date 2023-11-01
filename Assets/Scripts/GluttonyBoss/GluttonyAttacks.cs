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
    // Start is called before the first frame update
    void Start()
    {
        bossAnimator = GetComponent<Animator>();
        attackTimer = timeBetweenAttacks * 2; // Gives the player double the time on spawn to prepare for an attack.
        GlutMove = transform.parent.gameObject.GetComponent<GluttonyMove>();
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
        int randomAttack = Random.Range(1, 4);
        Debug.Log(randomAttack);
        // Will set the animator's "Attack" parameter to the random attack, triggering that animation.
        bossAnimator.SetInteger("Attack", randomAttack);
        // Sets isAttacking to true to prevent resets.
        isAttacking = true;
    }

    public void SetAttackingFalse()
    {
        this.isAttacking = false;
        Debug.Log("ddddddddddddddddd");
        bossAnimator.SetInteger("Attack", 0);
    }

    public void ChargePlayer(){
        GlutMove.ChargePlayer();
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
        newPrefabInstance.GetComponent<GluttonyProj>().targetPosition = new Vector2(playerTargetX, playerTargetY);
        newPrefabInstance = Instantiate(fireball, gameObject.transform.position, Quaternion.identity);
        newPrefabInstance.GetComponent<GluttonyProj>().targetPosition = new Vector2(playerTargetX + 5, playerTargetY);
        newPrefabInstance.GetComponent<GluttonyProj>().arcHeight = defaultArcHeight - 2;
        newPrefabInstance = Instantiate(fireball, gameObject.transform.position, Quaternion.identity);
        newPrefabInstance.GetComponent<GluttonyProj>().targetPosition = new Vector2(playerTargetX - 5, playerTargetY);
        newPrefabInstance.GetComponent<GluttonyProj>().arcHeight = defaultArcHeight + 2;
        // for (int i = 0; i < 3; i++) {

        // }
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
