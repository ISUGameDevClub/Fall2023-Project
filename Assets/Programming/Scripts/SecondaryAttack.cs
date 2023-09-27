using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class SecondaryAttack : MonoBehaviour
{
    [Header("Player Info")]
    public SpriteRenderer spriteRenderer;

    [Header("Attack Objects")]
    public GameObject secondaryAttackOne;
    public GameObject secondaryAttackTwoR;
    public GameObject secondaryAttackTwoL;
    public GameObject secondaryAttackTwoU;

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
    public float attackTwoDestroyTime = .2f;
    public float attackTwoCooldown = 2f;
    public bool debounce;
    
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        secondaryAttackTwoR.SetActive(false);
        secondaryAttackTwoL.SetActive(false);
        secondaryAttackTwoU.SetActive(false);
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
                StartCoroutine(SecondaryOne());
                //insert method that subtracts from currency
                Debug.Log("Secondary Attack 1 Pressed");
            }
        }
        //melee
        else if(weaponState == 2) 
        {
            if(Input.GetKeyDown(KeyCode.Mouse1) && canUseSecondaryAttack)
            {
                if(!debounce)
                {
                    debounce = true;
                    StartCoroutine(SecondaryTwo());
                    //insert method that subtracts from currency
                    Debug.Log("Secondary Attack 2 Pressed");
                }
                
            }
        }
        //to be determined
        else if(weaponState == 3)
        {
            //insert third secondary weapon state functionality
        }
        
        
    }

    //Note that secondary attacks do not need to be projectiles. All of this is placeholder until we have solid ideas
    private IEnumerator SecondaryOne()
    {
        //Instantiates object. Can add other functionality upon request. Will currently move object forward along x axis at designated speed
        GameObject clone;
        clone = Instantiate(secondaryAttackOne, transform.position + new Vector3(1,0,0), transform.rotation); //will set transform to players weapon when model is implemented
        clone.GetComponent<Rigidbody2D>().velocity = new Vector3(objectOneTravelSpeed,0,0);
        yield return new WaitForSeconds(.1f);
    }

    //Enables then disables collider
    //collider is not visible in game view
    private IEnumerator SecondaryTwo()
    {
        if(Input.GetKey(KeyCode.W))
        {
            secondaryAttackTwoU.SetActive(true);
            yield return new WaitForSeconds(attackTwoDestroyTime);
            secondaryAttackTwoU.SetActive(false);
        }
        else if(spriteRenderer.flipX == false)
        {
            secondaryAttackTwoR.SetActive(true);
            yield return new WaitForSeconds(attackTwoDestroyTime);
            secondaryAttackTwoR.SetActive(false);
        }
        //Check direction player is facing(will only attack right because no code exists to flip player)
        else if(spriteRenderer.flipX == true)
        {
            secondaryAttackTwoL.SetActive(true);
            yield return new WaitForSeconds(attackTwoDestroyTime);
            secondaryAttackTwoL.SetActive(false);
        }
        
        yield return new WaitForSeconds(attackTwoCooldown);
        debounce = false;
        
    }

}
