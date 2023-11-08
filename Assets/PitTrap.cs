using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitTrap : MonoBehaviour
{
    PlayerHealth playerHealth;
    [SerializeField] GameObject leftRespawnPoint;
    [SerializeField] GameObject rightRespawnPoint;
    private GameObject player;
    [SerializeField] int healthLoss;
    bool left;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMovement>())
        {
            player.GetComponent<PlayerHealth>().DamagePlayer(healthLoss,Vector3.zero);
            if((transform.position.x-collision.GetComponent<PlayerMovement>().GetLastGroundedPosition().x)>=0f){
                player.transform.position = leftRespawnPoint.transform.position;
            }else{
                player.transform.position = rightRespawnPoint.transform.position;
            }
        }
    }
}
