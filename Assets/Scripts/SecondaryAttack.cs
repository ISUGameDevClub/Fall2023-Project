using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class SecondaryAttack : MonoBehaviour
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
    
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
    void Update()
    {
        CheckForClick();
    }

    void CheckForClick()
    {
        if(weaponState == 0)
        {
            return;
        }
        //projectile
        else if(weaponState == 1)
        {
            if(Input.GetKeyDown(KeyCode.Mouse1) && canUseSecondaryAttack)
            {
                //tbd
                //insert method that subtracts from currency
                Debug.Log("Secondary Attack 1 Pressed");
            }
        }
        //melee
        else if(weaponState == 2) 
        {
            if(Input.GetKeyDown(KeyCode.Mouse1) && canUseSecondaryAttack)
            {   
                if(Time.time >= nextAttackTime)
                {
                    SecondaryTwo();
                    nextAttackTime = Time.time + 1f/attackRate; 
                } 
                   
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
        GameObject clone;
        clone = Instantiate(secondaryAttackOne, transform.position + new Vector3(1,0,0), transform.rotation); //will set transform to players weapon when model is implemented
        clone.GetComponent<Rigidbody2D>().velocity = new Vector3(objectOneTravelSpeed,0,0);
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


    //alter melee size via inspector
    void OnDrawGizmosSelected() 
    {
        if(attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, meleeAttackRange);
    }

}
