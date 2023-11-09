using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GluttonyMove : MonoBehaviour
{
    public float xMinWalkRange;
    public float xMaxWalkRange;
    private bool chargeAnimation = false;
    private int chargeDirection = 1;
    public int chargeSpeed = 3;
    public int ChargeRange = 4;
    private Vector2 chargeStart;
    private Vector2 targetRange;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Math.Abs(-8));
    }

    // Update is called once per frame
    void Update()
    {
        if (chargeAnimation){
            Vector2 bossPos = transform.position;
            Debug.Log(Math.Abs(bossPos.x - chargeStart.x));
            if (Math.Abs(bossPos.x - chargeStart.x) > ChargeRange) {
                Debug.Log("Range Done");
                chargeAnimation = false;
            }
            if (bossPos.x > xMinWalkRange || bossPos.x < xMaxWalkRange){
                transform.position = new Vector2(bossPos.x + (chargeSpeed * Time.deltaTime * chargeDirection),bossPos.y);
            } else {
                chargeAnimation = false;
            }
        }
    }

    public void ChargePlayer() {
        chargeStart = transform.position;
        chargeAnimation = true;
        Transform playerLocation = GameObject.FindGameObjectWithTag("Player").transform;
        if (transform.position.x < playerLocation.position.x) {
            // Player is on the right side
            chargeDirection = 1;
            targetRange = new Vector2(transform.position.x + ChargeRange,0);
        } else {
            // Player is on the left side
            chargeDirection = -1;
            targetRange = new Vector2(transform.position.x - ChargeRange,0);
        }
    }
}
