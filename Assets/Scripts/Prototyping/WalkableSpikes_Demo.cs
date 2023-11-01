using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkableSpikes_Demo : MonoBehaviour
{
    [SerializeField]
    private int damage;

    

    //This should work with i-frames to stop damage.
    private void OnCollisionStay2D(Collision2D collision)
    {   
        // We'll want to update this so no knockback is applied to the player, they get i-frames, and they can still walk.
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth)
        {
            playerHealth.DamagePlayer(damage, collision.GetContact(0).point);
        }
    }
    

    // Old demo logic
    /*
        private void OnCollisionEnter2D(Collision2D collision)
        {
            PlayerHealth_Demo playerHealth = collision.gameObject.GetComponent<PlayerHealth_Demo>();
            if (playerHealth)
            {
                playerHealth.TakeDamage(damage);
            }
        }
    */
}
