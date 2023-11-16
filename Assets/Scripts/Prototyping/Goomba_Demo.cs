using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;


public class Goomba_Demo : MonoBehaviour, IDamageable_Demo
{
    //Goomba enemy should walk through the player and we should be able to use this script for all enemies. we can create a string that has a dropdown of values in inspector that changes what type of enemy it is. Can also be an int if we want to do that for testing. lmk if you have questions -c
    [SerializeField] private float health;

    [SerializeField] private int moveSpeed;

    [SerializeField]
    private float damage;

    [SerializeField] SpriteRenderer sprite;

    //[SerializeField]
    //private Collider2D pitDetector;

    //[SerializeField]
    //private LayerMask nonPitMask;

    //private ContactFilter2D contactFilter;

    Animator animator;


    private void Awake()
    {
        //contactFilter.SetLayerMask(nonPitMask);
    }

    //true is forward, false is backwards
    private bool direction;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (direction)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
        }
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    //detects collison with anything but the player and reverses the movement
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "Player")
        {
            direction = !direction;
            //pitDetector.transform.position = new Vector2(-pitDetector.transform.position.x, pitDetector.transform.position.y);
            sprite.flipX = !sprite.flipX;
        }
        else if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth_Demo>().TakeDamage(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "FakeWall")
        {
            direction = !direction;
            sprite.flipX = !sprite.flipX;
        }
    }

    private void FixedUpdate()
    {
        /*List<Collider2D> nonPitColliders = new List<Collider2D>();
        pitDetector.OverlapCollider(contactFilter, nonPitColliders);

        if (nonPitColliders.Count == 0)
        {
            direction = !direction;
            pitDetector.transform.position = new Vector2(-pitDetector.transform.position.x, pitDetector.transform.position.y);
            sprite.flipX = !sprite.flipX;
        }*/
    }

    public void TakeDamage(float damageTaken)
    {
        health = health - damageTaken;
        animator.SetBool("Attacked", true);
    }
}
