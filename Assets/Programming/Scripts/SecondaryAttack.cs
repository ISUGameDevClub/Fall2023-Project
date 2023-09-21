using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
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
            //insert second secondary weapon state functionality
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

}
