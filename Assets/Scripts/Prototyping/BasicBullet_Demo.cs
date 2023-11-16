using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet_Demo : MonoBehaviour
{
    //Make sure that this works with the EnemyController.cs (Assets\Scripts\EnemyController.cs) script (Talk with Michael Tunberg) - C
    [SerializeField] int damage;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<IDamageable_Demo>().TakeDamage(damage);
            Destroy(this.gameObject);
        }

    }
}
