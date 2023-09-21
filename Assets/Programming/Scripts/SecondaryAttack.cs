using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryAttack : MonoBehaviour
{
    [Header("Attack Objects")]
    public GameObject secondaryAttackOne;
    public GameObject secondaryAttackTwo;
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
        else if(weaponState == 1)
        {
            if(Input.GetKeyDown(KeyCode.Mouse1) && canUseSecondaryAttack)
            {
                StartCoroutine(SecondaryOne());
                Debug.Log("Secondary Attack 1 Pressed");
            }
        }
        else if(weaponState == 2)
        {
            if(Input.GetKeyDown(KeyCode.Mouse1) && canUseSecondaryAttack)
            {
                StartCoroutine(SecondaryTwo());
                Debug.Log("Secondary Attack 2 Pressed");
            }
        }
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

    //Instantiate a temporary collider (Can make a permanent object that can be enabled/disabled when button is clicked instead(will allow hitbox to follow player))
    //collider is not visible in game view
    private IEnumerator SecondaryTwo()
    {
        GameObject melee1;
        melee1 = Instantiate(secondaryAttackTwo, transform.position + new Vector3(1.6f,.8f,0), transform.rotation);
        yield return new WaitForSeconds(attackTwoDestroyTime);
        Destroy(melee1);
    }

}
