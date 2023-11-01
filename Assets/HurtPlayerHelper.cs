using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerHelper : MonoBehaviour
{
    private GameObject player;
    public int damageToPlayer = 1;
    public float knockback = 1;

    private void Start()
    {
        player = FindObjectOfType<PlayerHealth>().gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            player.GetComponent<PlayerHealth>().DamagePlayer(damageToPlayer, transform.position);
        }
    }
}
