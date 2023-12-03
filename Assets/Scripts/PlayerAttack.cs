using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private int secondaryWeapon = 0;
    private int primaryWeapon = 0;
    private bool isRight = true;

    [SerializeField] GameObject weapon;
    [SerializeField] Transform attackPoint;

    [Header("Enemy")]
    [SerializeField] LayerMask enemyLayer;

    [Header("Bullets")]
    public GameObject simpleCannonBullet;
    public GameObject megaShotBullet;
    public GameObject daggerBullet;
    public GameObject grenadeLauncherBullet;

    [Header("Projectile Speeds")]
    public float simpleCannonSpeed = 10f;
    public float megaShotSpeed;

    [Header("SFX")]
    private SFXController sfxController;

    //Shoot Timers
    private bool canPrimary = true;
    private float currPrimaryTimer;
    public float timeBetweenPrimary = .25f;

    private bool canSecondary = true;
    private float currSecondaryTimer;
    public float timeBetweenSecondary = .5f;

    void Start()
    {
        sfxController = FindObjectOfType<SFXController>();
    }

    void Update() 
    {
        //Discerns last direction player was facing
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            isRight = true;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            isRight = false;
        }

        //Shoot Timers
        if (!canPrimary)
        {
            if(currPrimaryTimer <= 0)
            {
                currPrimaryTimer = timeBetweenPrimary;
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
                currSecondaryTimer = timeBetweenSecondary;
                canSecondary = true;
            }
            else
            {
                currSecondaryTimer -= Time.deltaTime;
            }
        }

        //Inputs
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(canPrimary)
            {
                canPrimary = false;
                ShootPrimaryWeapon();
            }
        }
        if(Input.GetKeyDown(KeyCode.Mouse1))
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
        if(primaryWeapon == 0)
        {
            ShootSimpleCannon();
        }
    }

    /* ----------------------
     * Primary Weapons
     ----------------------- */
    private void ShootSimpleCannon()
    {
        GetComponent<Animator>().SetTrigger("AttackStyle1");
        sfxController.playSound(3);
        GameObject clone;
        clone = Instantiate(simpleCannonBullet, weapon.transform.position, transform.rotation);
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            clone.GetComponent<Rigidbody2D>().velocity = new Vector3(1, 1, 0) * simpleCannonSpeed;
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            clone.GetComponent<Rigidbody2D>().velocity = new Vector3(-1, 1, 0) * simpleCannonSpeed;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            clone.GetComponent<Rigidbody2D>().velocity = new Vector3(-1, -1, 0) * simpleCannonSpeed;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            clone.GetComponent<Rigidbody2D>().velocity = new Vector3(1, -1, 0) * simpleCannonSpeed;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            clone.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 1, 0) * simpleCannonSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            clone.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -1, 0) * simpleCannonSpeed;
        }
        else if (isRight)
        {
            clone.GetComponent<Rigidbody2D>().velocity = new Vector3(1, 0, 0) * simpleCannonSpeed;
        }
        else if (!isRight)
        {
            clone.GetComponent<Rigidbody2D>().velocity = new Vector3(-1, 0, 0) * simpleCannonSpeed;
        }
    }




    /* ----------------------
     * Secondary Weapons
     ----------------------- */
    void ShootSecondaryWeapon(){
        //Mega-Shot
        if(secondaryWeapon == 1)
        {
            StartCoroutine(ShootMegaShot());
        }
        //Dagger
        else if(secondaryWeapon == 2) 
        {
            MeleeDagger();
        }
        //GrenadeLauncher
        else if(secondaryWeapon == 3)
        {
            //insert third secondary weapon state functionality
        }
    }
    private IEnumerator ShootMegaShot()
    {
        //Instantiates object. Can add other functionality upon request. Will currently move object forward along x axis at designated speed
        sfxController.playSound(4);
        GetComponent<Animator>().SetTrigger("AttackStyle1");
        GameObject clone;
        clone = Instantiate(megaShotBullet, attackPoint.transform.position, transform.rotation); //will set transform to players weapon when model is implemented
        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
                clone.GetComponent<Rigidbody2D>().velocity = new Vector3(1,1,0) * megaShotSpeed;
            }
            else if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
            {
                clone.GetComponent<Rigidbody2D>().velocity = new Vector3(-1,1,0) * megaShotSpeed;
            }
            else if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
            {
                clone.GetComponent<Rigidbody2D>().velocity = new Vector3(-1,-1,0) * megaShotSpeed;
            }
            else if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
            {
                clone.GetComponent<Rigidbody2D>().velocity = new Vector3(1,-1,0) * megaShotSpeed;
            }
            else if(Input.GetKey(KeyCode.W))
            {
                clone.GetComponent<Rigidbody2D>().velocity = new Vector3(0,1,0) * megaShotSpeed;
            }
            else if(Input.GetKey(KeyCode.S))
            {
                clone.GetComponent<Rigidbody2D>().velocity = new Vector3(0,-1,0) * megaShotSpeed;
            }
            else if(isRight)
            {
                clone.GetComponent<Rigidbody2D>().velocity = new Vector3(1,0,0) * megaShotSpeed;
            }
            else if(!isRight)
            {
                clone.GetComponent<Rigidbody2D>().velocity = new Vector3(-1,0,0) * megaShotSpeed;
            }
        yield return new WaitForSeconds(.1f);
    }

    private void MeleeDagger()
    {

    }

    /* ----------------------
     * Helper Functions
     ----------------------- */
    public void setPrimaryWeapon(int newPrimaryWeapon)
    {
        this.primaryWeapon = newPrimaryWeapon;
    }
    public void setSecondaryWeapon(int newSecondaryWeapon)
    {
        this.secondaryWeapon = newSecondaryWeapon;
    }
}
