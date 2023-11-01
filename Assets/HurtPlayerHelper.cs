using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayerHelper : MonoBehaviour
{
    private GameObject player;
    public int damageToPlayer = 1;

    private void Start()
    {
        player = FindObjectOfType<PlayerHealth>().gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            player.GetComponent<PlayerHealth>().DamagePlayer(damageToPlayer, Vector3.zero);
        }
    }
}
