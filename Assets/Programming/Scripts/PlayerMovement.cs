using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Transform playerTransform;

    // Update is called once per frame
    void Update()
    {
        playerTransform = transform;
        LeftRightMove();
    }
    void LeftRightMove()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.position = new Vector2(transform.position.x + Input.GetAxis("Horizontal") * speed, transform.position.y);
        }
    }
}
