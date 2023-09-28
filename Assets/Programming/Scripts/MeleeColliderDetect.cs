using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeColliderDetect : MonoBehaviour
{
    [Header("Other Scripts")]
    public TempEnemyScript enemyScript;

    public int damage;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Enemy")
        {
            enemyScript.TakeDamage(damage);
        }
        Debug.Log("Enemy Hit");
    }
}
