using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepelGlutAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D c) {
        int direction = 1;
        if(c.gameObject.GetComponent<PlayerHealth>()){
            Transform playerLocation = GameObject.FindGameObjectWithTag("Player").transform;
            if (transform.position.x < playerLocation.position.x) {
                // Player is on the right side
                direction = 1;
            } else {
                // Player is on the left side
                direction = -1;
            }
            GameObject player = c.gameObject;
            Debug.Log("GGGGGGGGGGGGGGGGGGGGGGGGGg");
            player.GetComponent<Rigidbody2D>().AddForce(new Vector2(6000 * direction, 500));
        }
    }
}
