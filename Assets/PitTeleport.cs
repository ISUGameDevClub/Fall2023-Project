using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //playerHealth.DamagePlayer(healthLoss);
            player.transform.position = respawnPoint.transform.position;

        }
    }
}
