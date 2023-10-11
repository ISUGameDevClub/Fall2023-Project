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

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update() 
    {
        ShootWeapon();    
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
            else if(!spriteRenderer.flipX)
            {
                clone.GetComponent<Rigidbody2D>().velocity = new Vector3(1,0,0) * travelSpeed;
            }
            else if(spriteRenderer.flipX)
            {
                clone.GetComponent<Rigidbody2D>().velocity = new Vector3(-1,0,0) * travelSpeed;
            }
        }
    }


}
