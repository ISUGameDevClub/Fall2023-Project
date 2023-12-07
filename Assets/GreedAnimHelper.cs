using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreedAnimHelper : MonoBehaviour
{
    private GreedBoss greedBossAttacks;

    // Start is called before the first frame update
    void Start()
    {
        greedBossAttacks = GetComponentInParent<GreedBoss>();
    }

    public void ThrowCard()
    {
        greedBossAttacks.ThrowCard();
    }

    public void SetAttackFalse()
    {
        greedBossAttacks.isAttacking = false;
    }



    //Hurt player if touching boss.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerHealth>())
        {
            GameObject player = collision.gameObject;
            player.GetComponent<PlayerHealth>().DamagePlayer(greedBossAttacks.damage, transform.position);
        }
    }
}
