using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeDestroy : MonoBehaviour
{
    public GameObject explosion;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.GetComponent<Coin>() && !other.GetComponent<HealthPickup>())
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        
    }
}
