using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GluttonyMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anims;

    public float xMinWalkRange;
    public float xMaxWalkRange;
    private bool chargeAnimation = false;
    private int chargeDirection = 1;
    public int chargeSpeed = 3;
    public float ChargeRange = 12.5f;
    private Vector2 chargeStart;
    private Vector2 targetRange;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (chargeAnimation) {
            Vector2 bossPos = rb.position;
            if (Math.Abs(bossPos.x - chargeStart.x) > ChargeRange) {
                Debug.Log("Range Done");
                chargeAnimation = false;
            }
            if (bossPos.x > xMinWalkRange || bossPos.x < xMaxWalkRange){
                rb.position = new Vector2(bossPos.x + (chargeSpeed * Time.deltaTime * chargeDirection),bossPos.y);
            } else {
                chargeAnimation = false;
            }
        }
    }

    public void ChargePlayer() {
        chargeStart = rb.position;
        chargeAnimation = true;
        Transform playerLocation = GameObject.FindGameObjectWithTag("Player").transform;
        if (rb.position.x < playerLocation.position.x) {
            // Player is on the right side
            chargeDirection = 1;
            targetRange = new Vector2(rb.position.x + ChargeRange,0);
        } else {
            // Player is on the left side
            chargeDirection = -1;
            targetRange = new Vector2(rb.position.x - ChargeRange,0);
        }
    }
}
