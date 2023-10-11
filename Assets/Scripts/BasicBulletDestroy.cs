using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBulletDestroy : MonoBehaviour
{
    [SerializeField] int damage;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Enemy")
        {
        //                insert title of enemy script
            other.GetComponent<TempEnemyScript>().TakeDamage(damage);
            Destroy(gameObject);
        }
        
    }


  
}
