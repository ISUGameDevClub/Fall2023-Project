using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] LayerMask enemyLayer;

    [Header("Player Info")]
    public SpriteRenderer spriteRenderer;

    [Header("Attack Objects")]
    public GameObject secondaryAttackOne;
    [SerializeField] Transform attackPoint;

    public GameObject secondaryAttackThree;

    [Header("Projectile Speeds")]
    public float objectOneTravelSpeed;
    public float objectTwoTravelSpeed;
    public float objectThreeTravelSpeed;

    [Header("Attack Information")]
    //Set to false when unable to use secondary attack (out of energy/currency)
    public bool canUseSecondaryAttack = true;
    public int weaponState = 0;
    //Alter this variable to change amount of time hitbox is active on attack two
    [Header("Attack Two Information")]
    [SerializeField] int meleeDamage;
    [SerializeField] float meleeAttackRange = 0.5f; 
    [SerializeField] float attackRate = 2f;
    [SerializeField] float nextAttackTime = 0f;

    [SerializeField] GameObject bullet;
    [SerializeField] GameObject weapon;

    [Header("SFX")]
    private SFXController sfxController;

    public float travelSpeed = 10f;
    [SerializeField] bool isRight = true;

    //Shoot Timers
    private bool canPrimary = true;
    private float currPrimaryTimer;
    public float primaryTimer = .25f;

    private bool canSecondary = true;
    private float currSecondaryTimer;
    public float secondaryTimer = .5f;

    void Start()
    {
        sfxController = FindObjectOfType<SFXController>();
    }

    void Update() 
    {
        if(!canPrimary)
        {
            if(currPrimaryTimer <= 0)
            {
                currPrimaryTimer = primaryTimer;
                canPrimary = true;
            }
            else
            {
                currPrimaryTimer -= Time.deltaTime;
            }
        }
        if(!canSecondary)
        {
            if (currSecondaryTimer <= 0)
            {
                currSecondaryTimer = secondaryTimer;
                canSecondary = true;
            }
            else
            {
                currSecondaryTimer -= Time.deltaTime;
            }
        }


        CheckDirection();
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(canPrimary)
            {
                canPrimary = false;
                ShootPrimaryWeapon();
            }
        }
        if(Input.GetKeyDown(KeyCode.Mouse1) && canUseSecondaryAttack)
        {
            if(canSecondary)
            {
                canSecondary = false;
                ShootSecondaryWeapon();
            }

        }
    }

    void ShootPrimaryWeapon()
    {
            GetComponent<Animator>().SetTrigger("AttackStyle1");
            sfxController.playSound(3);
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
    void ShootSecondaryWeapon(){
        if(weaponState == 0)
        {
            return;
        }
        //projectile
        else if(weaponState == 1)
        {
            //tbd
            //insert method that subtracts from currency
            StartCoroutine(SecondaryOne());
            Debug.Log("Secondary Attack 1 Pressed");
        }
        //melee
        else if(weaponState == 2) 
        {
            if(Time.time >= nextAttackTime)
            {
                SecondaryTwo();
                nextAttackTime = Time.time + 1f/attackRate; 
            }
        }
        //to be determined
        else if(weaponState == 3)
        {
            //insert third secondary weapon state functionality
        }
    }
    private IEnumerator SecondaryOne()
    {
        //Instantiates object. Can add other functionality upon request. Will currently move object forward along x axis at designated speed
        sfxController.playSound(4);
        GetComponent<Animator>().SetTrigger("AttackStyle1");
        GameObject clone;
        clone = Instantiate(secondaryAttackOne, attackPoint.transform.position, transform.rotation); //will set transform to players weapon when model is implemented
        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
                clone.GetComponent<Rigidbody2D>().velocity = new Vector3(1,1,0) * objectOneTravelSpeed;
            }
            else if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
            {
                clone.GetComponent<Rigidbody2D>().velocity = new Vector3(-1,1,0) * objectOneTravelSpeed;
            }
            else if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
            {
                clone.GetComponent<Rigidbody2D>().velocity = new Vector3(-1,-1,0) * objectOneTravelSpeed;
            }
            else if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
            {
                clone.GetComponent<Rigidbody2D>().velocity = new Vector3(1,-1,0) * objectOneTravelSpeed;
            }
            else if(Input.GetKey(KeyCode.W))
            {
                clone.GetComponent<Rigidbody2D>().velocity = new Vector3(0,1,0) * objectOneTravelSpeed;
            }
            else if(Input.GetKey(KeyCode.S))
            {
                clone.GetComponent<Rigidbody2D>().velocity = new Vector3(0,-1,0) * objectOneTravelSpeed;
            }
            else if(isRight)
            {
                clone.GetComponent<Rigidbody2D>().velocity = new Vector3(1,0,0) * objectOneTravelSpeed;
            }
            else if(!isRight)
            {
                clone.GetComponent<Rigidbody2D>().velocity = new Vector3(-1,0,0) * objectOneTravelSpeed;
            }
        yield return new WaitForSeconds(.1f);
    }

    //Enables circular collider around player
    //collider is not visible in game view
    private void SecondaryTwo()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, meleeAttackRange, enemyLayer);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("Hit " + enemy.name);
            enemy.GetComponent<TempEnemyScript>().TakeDamage(meleeDamage);
        }
            
    }
    void CheckDirection()
    {
        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            isRight = true;
            spriteRenderer.flipX=false;
        }
        else if(Input.GetAxisRaw("Horizontal") < 0 )
        {
            isRight = false;
            spriteRenderer.flipX=true;
        }
    }
}
