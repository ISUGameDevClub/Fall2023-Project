using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour{

    [SerializeField] private int health;
    
    [SerializeField] private int moveSpeed;

    //true is forward, false is backwards
    private bool direction;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        if (direction){
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        else {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
    }

    //detects collison with anything but the player and reverses the movement
    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.tag != "Player" && direction){
            direction = false;
        }
        else if (other.gameObject.tag != "Player" && !direction){
            direction = true;
        }
    }

    public void TakeDamage(int damageTaken){
        health = health - damageTaken;
    }
}