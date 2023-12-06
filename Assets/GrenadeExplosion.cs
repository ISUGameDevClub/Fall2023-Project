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
            FindObjectOfType<DMCombo>().AddToCombo();
        }
        if(other.gameObject.GetComponent<ContraEnemyController>())
        {
            other.GetComponent<ContraEnemyController>().TakeDamage(damage);
            FindObjectOfType<DMCombo>().AddToCombo();
        }
        if(other.gameObject.GetComponent<ParasiteController>())
        {
            other.GetComponent<ParasiteController>().TakeDamage(damage);
            FindObjectOfType<DMCombo>().AddToCombo();
        }   
        if (other.CompareTag("WrathBoss"))
        {
            //Not sure if this is the proper place we're handling hurting enemies...
            other.GetComponentInParent<DragonBossHealth>().TakeDamage(damage);
            FindObjectOfType<DMCombo>().AddToCombo();
        }
        if (other.CompareTag("GluttonyBoss"))
        {
            other.GetComponentInParent<GluttonyHealth>().TakeDamage(damage);
            FindObjectOfType<DMCombo>().AddToCombo();
        }
        if (!other.CompareTag("Player") && !other.CompareTag("2Way"))
        {
            Destroy(gameObject);
        }
    }

    //Handles explosion in animator.
    public void ExplosionAnimEvent()
    {
        Destroy(gameObject);
    }  
}
