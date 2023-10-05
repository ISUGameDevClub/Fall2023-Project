using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBulletDestroy : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.GetComponent<TempEnemyScript>().TakeDamage(1);
            Destroy(gameObject);
        }
        
    }


  
}
