using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour{

    [SerializeField] private int health;
    
    [SerializeField] private double moveSpeed;

    //true is forward, false is backwards
    private bool direction;
    SpriteRenderer enemyRenderer;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        
    }

    //called to subtract enemy health and blink out for a frame to signify being hit
    public void Damage(int damageTaken){
        health = health - damageTaken;
        enemyRenderer = GetComponent<SpriteRenderer>();
        //Change the GameObject's Material Color to white
        enemyRenderer.enabled = false;
        //--CODY COMMENTED OUT BELOW--//
        //You need to make this method an IEnumerator if you want to use yield return
        //yield return new WaitForSeconds(1);
        enemyRenderer.enabled = true;
    }

    //detects collison with anything but the player and reverses the movement
    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.tag != "Player" && direction){
            direction = false;
            enemyRenderer.flipX = true;
        }
        else if (other.gameObject.tag != "Player" && !direction){
            direction = true;
            enemyRenderer.flipX = false;
        }
    }
}