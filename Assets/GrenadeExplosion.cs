using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplosion : MonoBehaviour
{
    public float damage;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<EnemyController>())
        {
            other.GetComponent<EnemyController>().TakeDamage(damage);
        }
        if (other.CompareTag("WrathBoss"))
        {
            //Not sure if this is the proper place we're handling hurting enemies...
            other.GetComponentInParent<DragonBossHealth>().TakeDamage(damage);
        }
    }

    //Handles explosion in animator.
    public void ExplosionAnimEvent()
    {
        Destroy(gameObject);
    }  
}
