using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PrimaryAttack : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    [SerializeField] GameObject bullet;
    [SerializeField] GameObject weapon;


    public float travelSpeed = 10f;
    [SerializeField] bool isRight = true;

    void Start()
    {

    }

    void Update() 
    {
        ShootWeapon();
        CheckDirection();    
    }

    void ShootWeapon()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Debug.Log("bullet shot");
            GameObject clone;
            clone = Instantiate(bullet, weapon.transform.position, transform.rotation);
            
            if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
                clone.GetComponent<Rigidbody2D>().velocity = new Vector3(1,1,0) * travelSpeed;
            }
            else if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
            {
                clone.GetComponent<Rigidbody2D>().velocity = new Vector3(-1,1,0) * travelSpeed;
            }
            else if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
            {
                clone.GetComponent<Rigidbody2D>().velocity = new Vector3(-1,-1,0) * travelSpeed;
            }
            else if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
            {
                clone.GetComponent<Rigidbody2D>().velocity = new Vector3(1,-1,0) * travelSpeed;
            }
            else if(Input.GetKey(KeyCode.W))
            {
                clone.GetComponent<Rigidbody2D>().velocity = new Vector3(0,1,0) * travelSpeed;
            }
            else if(Input.GetKey(KeyCode.S))
            {
                clone.GetComponent<Rigidbody2D>().velocity = new Vector3(0,-1,0) * travelSpeed;
            }
            else if(isRight)
            {
                clone.GetComponent<Rigidbody2D>().velocity = new Vector3(1,0,0) * travelSpeed;
            }
            else if(!isRight)
            {
                clone.GetComponent<Rigidbody2D>().velocity = new Vector3(-1,0,0) * travelSpeed;
            }
        }
    }

    void CheckDirection()
    {
        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            isRight = true;
        }
        else if(Input.GetAxisRaw("Horizontal") < 0 )
        {
            isRight = false;
        }
    }
    
}
