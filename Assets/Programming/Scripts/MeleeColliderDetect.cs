using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeColliderDetect : MonoBehaviour
{
   public int damage;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<TempEnemyScript>().TakeDamage(damage);
            Debug.Log("melee collision detected");
        }
    }
}
