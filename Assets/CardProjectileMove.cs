using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardProjectileMove : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    { 
        Destroy(gameObject, 10f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMovement>())
        {
            Destroy(gameObject);
        }
    }
}
