using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    private SFXController sfxController;

    private PlayerHealth playerHealth;
    public float healAmount;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        sfxController = FindObjectOfType<SFXController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            sfxController.playSound(10);
            playerHealth.HealPlayer(healAmount);
            Destroy(gameObject);
        }
    }
}
