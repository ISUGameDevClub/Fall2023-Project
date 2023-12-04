using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private int secondaryWeapon = 0;
    private int primaryWeapon = 0;
    private bool isRight = true;

    //Secondaries in Inventory
    public static bool hasMegaShot = false;
    public static bool hasDagger = false;
    public static bool hasGrenadeLauncher = false;

    [SerializeField] GameObject weapon;
    [SerializeField] Transform attackPoint;

    [Header("Enemy")]
    [SerializeField] LayerMask enemyLayer;

    [Header("Bullets")]
    public GameObject simpleCannonBullet;
    public GameObject railgunBullet;
    public GameObject megaShotBullet;
    public GameObject daggerBullet;
    public GameObject grenadeLauncherBullet;

    [Header("Projectile Speeds")]
    public float simpleCannonSpeed = 10f;
    public float megaShotSpeed;
    public float daggerSliceSpeed = .2f;
    public float grenadeSpeed = 10f;

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
        //Also changes direction of weapon
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            isRight = true;
            attackPoint.transform.localPosition = new Vector3(.75f, 1, 0);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            isRight = false;
            attackPoint.transform.localPosition = new Vector3(-.75f, 1, 0);
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
        else if(primaryWeapon == 1)
        {
            ShootRailgun();
        }
    }

    /* ----------------------
     * Primary Weapons
     ----------------------- */
    private void ShootSimpleCannon()
    {
        GetComponent<Animator>().SetInteger("WeaponType", 0);
        sfxController.playSound(3);
        GameObject clone;
        clone = Instantiate(simpleCannonBullet, weapon.transform.position, transform.rotation);
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            GetComponent<Animator>().SetInteger("ShootDir", 1);
            clone.GetComponent<Rigidbody2D>().velocity = new Vector3(1, 1, 0) * simpleCannonSpeed;
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            GetComponent<Animator>().SetInteger("ShootDir", 1);
            clone.GetComponent<Rigidbody2D>().velocity = new Vector3(-1, 1, 0) * simpleCannonSpeed;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            GetComponent<Animator>().SetInteger("ShootDir", 3);
            clone.GetComponent<Rigidbody2D>().velocity = new Vector3(-1, -1, 0) * simpleCannonSpeed;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            GetComponent<Animator>().SetInteger("ShootDir", 3);
            clone.GetComponent<Rigidbody2D>().velocity = new Vector3(1, -1, 0) * simpleCannonSpeed;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Animator>().SetInteger("ShootDir", 0);
            clone.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 1, 0) * simpleCannonSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Animator>().SetInteger("ShootDir", 4);
            clone.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -1, 0) * simpleCannonSpeed;
        }
        else if (isRight)
        {
            GetComponent<Animator>().SetInteger("ShootDir", 2);
            clone.GetComponent<Rigidbody2D>().velocity = new Vector3(1, 0, 0) * simpleCannonSpeed;
        }
        else if (!isRight)
        {
            GetComponent<Animator>().SetInteger("ShootDir", 2);
            clone.GetComponent<Rigidbody2D>().velocity = new Vector3(-1, 0, 0) * simpleCannonSpeed;
        }
        GetComponent<Animator>().SetTrigger("Shoot");
    }

    private void ShootRailgun()
    {
        GetComponent<Animator>().SetInteger("WeaponType", 1);
        GameObject clone;
        clone = Instantiate(railgunBullet, weapon.transform.position, transform.rotation);
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            GetComponent<Animator>().SetInteger("ShootDir", 1);
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            GetComponent<Animator>().SetInteger("ShootDir", 1);
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            GetComponent<Animator>().SetInteger("ShootDir", 3);
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            GetComponent<Animator>().SetInteger("ShootDir", 3);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Animator>().SetInteger("ShootDir", 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Animator>().SetInteger("ShootDir", 4);
        }
        else if (isRight)
        {
            GetComponent<Animator>().SetInteger("ShootDir", 2);
        }
        else if (!isRight)
        {
            GetComponent<Animator>().SetInteger("ShootDir", 2);
        }
        GetComponent<Animator>().SetTrigger("Shoot");
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
            StartCoroutine(MeleeDagger());
        }
        //GrenadeLauncher
        else if(secondaryWeapon == 3)
        {
            ShootGrenadeLauncher();
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

    private IEnumerator MeleeDagger()
    {
        //TODO: Add sound
        //TODO: Add animation
        Instantiate(daggerBullet, attackPoint.transform.position, transform.rotation);
        yield return new WaitForSeconds(daggerSliceSpeed);
        Instantiate(daggerBullet, attackPoint.transform.position, transform.rotation);
        yield return new WaitForSeconds(daggerSliceSpeed);
        Instantiate(daggerBullet, attackPoint.transform.position, transform.rotation);
    }

    private void ShootGrenadeLauncher()
    {
        GameObject grenade = Instantiate(grenadeLauncherBullet, attackPoint.transform.position, transform.rotation);
        
        Rigidbody2D grenadeRigidbody = grenade.GetComponent<Rigidbody2D>();
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            grenadeRigidbody.velocity = new Vector2(.75f, 1) * grenadeSpeed;
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            grenadeRigidbody.velocity = new Vector2(-.75f, 1) * grenadeSpeed;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            grenadeRigidbody.velocity = new Vector2(-1, -1) * grenadeSpeed;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            grenadeRigidbody.velocity = new Vector2(1, -1) * grenadeSpeed;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            grenadeRigidbody.velocity = new Vector2(0, .75f) * grenadeSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            grenadeRigidbody.velocity = new Vector2(0, -1) * grenadeSpeed;
        }
        else if (isRight)
        {
            grenadeRigidbody.velocity = new Vector2(1, .25f) * grenadeSpeed;
        }
        else if (!isRight)
        {
            grenadeRigidbody.velocity = new Vector2(-1, .25f) * grenadeSpeed;
        }
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
