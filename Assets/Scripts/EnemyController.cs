using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour{

    [SerializeField] private int health;
    
    [SerializeField] private int moveSpeed;

    [SerializeField] SpriteRenderer sprite;

    //true is forward, false is backwards
    private bool direction;
    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update(){
        flicker();
        if (direction){
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        else {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
        if (health < 0){
            Destroy(this);
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

    private void flicker(){
        sprite.color = new Color(1f,1f,1f,0f);
        sprite.color = new Color(1f,1f,1f,100f);
    }
}
