using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardController : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] private int moveSpeed;

    [SerializeField] SpriteRenderer sprite;
    Rigidbody2D rb;

    [SerializeField] hazardSelection hazSelect;
    private bool direction;

    private int ballAggroDist = 5;
    public bool getDirection()
    {
        return direction;
    }

    private enum hazardSelection
    {
        //the Spiky Ball
        hazard1,
        //placeholder
        hazard2,
        //placeholder
        hazard3
    };

    Animator animator;

    void Start()
    {
        direction = true;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        switch (hazSelect)
        {
            //the Spiky Ball
            case hazardSelection.hazard1:
                {
                    break;
                }
            //placeholder
            case hazardSelection.hazard2:
                {
                    break;
                }
            //placeholder
            case hazardSelection.hazard3:
                {
                    break;
                }
        }
    }

    //detects collison with anything but the player and reverses the movement
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == 10 || other.gameObject.layer == 8)
        {
            direction = !direction;
        }
        if (other.gameObject.GetComponent<PlayerHealth>())
        {
            GameObject player = other.gameObject;
            player.GetComponent<PlayerHealth>().DamagePlayer(damage, transform.position);
        }
    }

    //the Spiky Ball
    private void updateHazard1()
    {
        //start jumping towards player when within certain range
        //if (player distance from me <= ballAggroDist)
        /*{
            //start doing jumps in that direction
            //mix in big jumps at random (or just do it at the end?)
            // end after a certain distance?
        }*/

        //wait a sec before jumping again?




        /*
        if (direction)
        {
            rb.MovePosition(rb.position + (Vector2.right * moveSpeed * Time.fixedDeltaTime));
            this.sprite.flipX = true;
        }
        else if (!direction)
        {
            rb.MovePosition(rb.position + (Vector2.left * moveSpeed * Time.fixedDeltaTime));
            this.sprite.flipX = false;
        }*/
    }

    //Then Perish
    void Die()
    {
        Destroy(gameObject);
    }
}
