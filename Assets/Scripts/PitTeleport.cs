using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitTeleport : MonoBehaviour
{   
    PlayerHealth playerHealth;
    public GameObject respawnPoint;
    private GameObject player;
    [SerializeField] int healthLoss;

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")//change this to detect if the colision has the playermovement or playerhealth script instead. this will be more consistent and faster than checking the tag
        {
            //playerHealth.DamagePlayer(healthLoss);
            player.transform.position = respawnPoint.transform.position;

        }
    }
}
