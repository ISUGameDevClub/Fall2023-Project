using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkableSpikes_Demo : MonoBehaviour
{
    [SerializeField]
    private float damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHealth_Demo playerHealth = collision.gameObject.GetComponent<PlayerHealth_Demo>();
        if (playerHealth)
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
