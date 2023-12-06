using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //TOMMY: SFX on Megashot, dagger, and grenade launcher (perhaps use goomba explosion)
    //...and railgun.

    public static int SecondaryWeapon = 0;
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

    private bool canPrimary = true;
    private float currPrimaryTimer;
    private bool canSecondary = true;
    private float currSecondaryTimer;


    [Header("Timers")]
    public float simpleCannonDelay = .5f;
    public float railgunDelay = 1f;
    public float megaShotDelay = .75f;
    public float daggerDelay = .5f;
    public float grenadeLauncherDelay = 1f;

    void Start()
    {
        sfxController = FindObjectOfType<SFXController>();
    }

    void Update() 
    {
        //TODO: DEBUGS, DELETE LATER
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("MegaShot");
            SecondaryWeapon = 1;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Dagger");
            SecondaryWeapon = 2;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("GrenadeLauncher");
            SecondaryWeapon = 3;
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log("Railgun");
            primaryWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Debug.Log("Simple Cannon");
            primaryWeapon = 0;
        }

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



    /* ----------------------
     * Primary Weapons
     ----------------------- */
    void ShootPrimaryWeapon()
    {
        if(primaryWeapon == 0)
        {
            currPrimaryTimer = simpleCannonDelay;
            ShootSimpleCannon();
        }
        else if(primaryWeapon == 1)
        {
            currPrimaryTimer = railgunDelay;
            ShootRailgun();
        }
    }

    private void ShootSimpleCannon()
    {
        GetComponent<Animator>().SetInteger("WeaponType", 0);
        sfxController.playSound(3);
        GameObject clone;
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            clone = Instantiate(simpleCannonBullet, weapon.transform.position, Quaternion.Euler(0, 0, 45));
            GetComponent<Animator>().SetInteger("ShootDir", 1);
            clone.GetComponent<Rigidbody2D>().velocity = new Vector3(1, 1, 0) * simpleCannonSpeed;
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            clone = Instantiate(simpleCannonBullet, weapon.transform.position, Quaternion.Euler(0, 0, 135));
            GetComponent<Animator>().SetInteger("ShootDir", 1);
            clone.GetComponent<Rigidbody2D>().velocity = new Vector3(-1, 1, 0) * simpleCannonSpeed;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            clone = Instantiate(simpleCannonBullet, weapon.transform.position, Quaternion.Euler(0, 0, 225));
            GetComponent<Animator>().SetInteger("ShootDir", 3);
            clone.GetComponent<Rigidbody2D>().velocity = new Vector3(-1, -1, 0) * simpleCannonSpeed;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            clone = Instantiate(simpleCannonBullet, weapon.transform.position, Quaternion.Euler(0, 0, 315));
            GetComponent<Animator>().SetInteger("ShootDir", 3);
            clone.GetComponent<Rigidbody2D>().velocity = new Vector3(1, -1, 0) * simpleCannonSpeed;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            clone = Instantiate(simpleCannonBullet, weapon.transform.position, Quaternion.Euler(0, 0, 90));
            GetComponent<Animator>().SetInteger("ShootDir", 0);
            clone.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 1, 0) * simpleCannonSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            clone = Instantiate(simpleCannonBullet, weapon.transform.position, Quaternion.Euler(0, 0, 270));
            GetComponent<Animator>().SetInteger("ShootDir", 4);
            clone.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -1, 0) * simpleCannonSpeed;
        }
        else if (isRight)
        {
            clone = Instantiate(simpleCannonBullet, weapon.transform.position, Quaternion.Euler(0, 0, 0));
            GetComponent<Animator>().SetInteger("ShootDir", 2);
            clone.GetComponent<Rigidbody2D>().velocity = new Vector3(1, 0, 0) * simpleCannonSpeed;
        }
        else if (!isRight)
        {
            clone = Instantiate(simpleCannonBullet, weapon.transform.position, Quaternion.Euler(0, 0, 180));
            GetComponent<Animator>().SetInteger("ShootDir", 2);
            clone.GetComponent<Rigidbody2D>().velocity = new Vector3(-1, 0, 0) * simpleCannonSpeed;
        }
        GetComponent<Animator>().SetTrigger("Shoot");
    }

    private void ShootRailgun()
    {
        GetComponent<Animator>().SetInteger("WeaponType", 1);
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            Instantiate(railgunBullet, weapon.transform.position, Quaternion.Euler(0, 0, 45));
            GetComponent<Animator>().SetInteger("ShootDir", 1);
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            Instantiate(railgunBullet, weapon.transform.position, Quaternion.Euler(0, 0, 135));
            GetComponent<Animator>().SetInteger("ShootDir", 1);
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            Instantiate(railgunBullet, weapon.transform.position, Quaternion.Euler(0, 0, 225));
            GetComponent<Animator>().SetInteger("ShootDir", 3);
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            Instantiate(railgunBullet, weapon.transform.position, Quaternion.Euler(0, 0, 315));
            GetComponent<Animator>().SetInteger("ShootDir", 3);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            Instantiate(railgunBullet, weapon.transform.position, Quaternion.Euler(0, 0, 90));
            GetComponent<Animator>().SetInteger("ShootDir", 0);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Instantiate(railgunBullet, weapon.transform.position, Quaternion.Euler(0, 0, 270));
            GetComponent<Animator>().SetInteger("ShootDir", 4);
        }
        else if (isRight)
        {
            Instantiate(railgunBullet, weapon.transform.position, Quaternion.Euler(0, 0, 0));
            GetComponent<Animator>().SetInteger("ShootDir", 2);
        }
        else if (!isRight)
        {
            Instantiate(railgunBullet, weapon.transform.position, Quaternion.Euler(0, 0, 180));
            GetComponent<Animator>().SetInteger("ShootDir", 2);
        }
        GetComponent<Animator>().SetTrigger("Shoot");
    }



    /* ----------------------
     * Secondary Weapons
     ----------------------- */
    void ShootSecondaryWeapon(){
        //Mega-Shot
        if(SecondaryWeapon == 1)
        {
            currSecondaryTimer = megaShotDelay;
            StartCoroutine(ShootMegaShot());
        }
        //Dagger
        else if(SecondaryWeapon == 2) 
        {
            currSecondaryTimer = daggerDelay;
            GetComponent<Animator>().SetInteger("WeaponType", 3);
            GetComponent<Animator>().SetTrigger("Shoot");
        }
        //GrenadeLauncher
        else if(SecondaryWeapon == 3)
        {
            currSecondaryTimer = grenadeLauncherDelay;
            ShootGrenadeLauncher();
        }
    }

    private IEnumerator ShootMegaShot()
    {
        //Instantiates object. Can add other functionality upon request. Will currently move object forward along x axis at designated speed
        sfxController.playSound(4);
        GetComponent<Animator>().SetInteger("WeaponType", 2);
        yield return new WaitForSeconds(.05f);
        GameObject clone;
        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            clone = Instantiate(megaShotBullet, attackPoint.transform.position, Quaternion.Euler(0,0,45));
            GetComponent<Animator>().SetInteger("ShootDir", 1);
            clone.GetComponent<Rigidbody2D>().velocity = new Vector3(1,1,0) * megaShotSpeed;
        }
        else if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            clone = Instantiate(megaShotBullet, attackPoint.transform.position, Quaternion.Euler(0,0,135));
            GetComponent<Animator>().SetInteger("ShootDir", 1);
            clone.GetComponent<Rigidbody2D>().velocity = new Vector3(-1,1,0) * megaShotSpeed;
        }
        else if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            clone = Instantiate(megaShotBullet, attackPoint.transform.position, Quaternion.Euler(0,0,225));
            GetComponent<Animator>().SetInteger("ShootDir", 3);
            clone.GetComponent<Rigidbody2D>().velocity = new Vector3(-1,-1,0) * megaShotSpeed;
        }
        else if(Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            clone = Instantiate(megaShotBullet, attackPoint.transform.position, Quaternion.Euler(0,0,315));
            GetComponent<Animator>().SetInteger("ShootDir", 3);
            clone.GetComponent<Rigidbody2D>().velocity = new Vector3(1,-1,0) * megaShotSpeed;
        }
        else if(Input.GetKey(KeyCode.W))
        {
            clone = Instantiate(megaShotBullet, attackPoint.transform.position, Quaternion.Euler(0,0,90));
            GetComponent<Animator>().SetInteger("ShootDir", 0);
            clone.GetComponent<Rigidbody2D>().velocity = new Vector3(0,1,0) * megaShotSpeed;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            clone = Instantiate(megaShotBullet, attackPoint.transform.position, Quaternion.Euler(0,0,270));
            GetComponent<Animator>().SetInteger("ShootDir", 4);
            clone.GetComponent<Rigidbody2D>().velocity = new Vector3(0,-1,0) * megaShotSpeed;
        }
        else if(isRight)
        {
            clone = Instantiate(megaShotBullet, attackPoint.transform.position, Quaternion.Euler(0,0,0));
            GetComponent<Animator>().SetInteger("ShootDir", 2);
            clone.GetComponent<Rigidbody2D>().velocity = new Vector3(1,0,0) * megaShotSpeed;
        }
        else if(!isRight)
        {
            clone = Instantiate(megaShotBullet, attackPoint.transform.position, Quaternion.Euler(0,0,180));
            GetComponent<Animator>().SetInteger("ShootDir", 2);
            clone.GetComponent<Rigidbody2D>().velocity = new Vector3(-1,0,0) * megaShotSpeed;
        }
        GetComponent<Animator>().SetTrigger("Shoot");
    }

    public void MeleeDaggerAnim()
    {
        float randomSwipeDirection = Random.Range(0, 2);

        ////TODO: Add sound
        if(isRight)
        {
            if(randomSwipeDirection == 0)
            {
                Instantiate(daggerBullet, attackPoint.transform.position, Quaternion.Euler(0, 0, 0));
            }
            else
            {
                Instantiate(daggerBullet, attackPoint.transform.position, Quaternion.Euler(130, 0, 0));
            }
        }    
        else
        {
            if(randomSwipeDirection == 0)
            {
                Instantiate(daggerBullet, attackPoint.transform.position, Quaternion.Euler(0, 0, 180));
            }
            else
            {
                Instantiate(daggerBullet, attackPoint.transform.position, Quaternion.Euler(130, 0, 180));
            }
        }
    }

    private void ShootGrenadeLauncher()
    {
        GetComponent<Animator>().SetInteger("WeaponType", 2);
        //TODO: Add sound
        GameObject grenade = Instantiate(grenadeLauncherBullet, attackPoint.transform.position, transform.rotation);
        Rigidbody2D grenadeRigidbody = grenade.GetComponent<Rigidbody2D>();

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            GetComponent<Animator>().SetInteger("ShootDir", 1);
            grenadeRigidbody.velocity = new Vector2(.75f, 1) * grenadeSpeed;
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            GetComponent<Animator>().SetInteger("ShootDir", 1);
            grenadeRigidbody.velocity = new Vector2(-.75f, 1) * grenadeSpeed;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            GetComponent<Animator>().SetInteger("ShootDir", 3);
            grenadeRigidbody.velocity = new Vector2(-1, -1) * grenadeSpeed;
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            GetComponent<Animator>().SetInteger("ShootDir", 3);
            grenadeRigidbody.velocity = new Vector2(1, -1) * grenadeSpeed;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Animator>().SetInteger("ShootDir", 0);
            grenadeRigidbody.velocity = new Vector2(0, .75f) * grenadeSpeed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Animator>().SetInteger("ShootDir", 4);
            grenadeRigidbody.velocity = new Vector2(0, -1) * grenadeSpeed;
        }
        else if (isRight)
        {
            GetComponent<Animator>().SetInteger("ShootDir", 2);
            grenadeRigidbody.velocity = new Vector2(1, .25f) * grenadeSpeed;
        }
        else if (!isRight)
        {
            GetComponent<Animator>().SetInteger("ShootDir", 2);
            grenadeRigidbody.velocity = new Vector2(-1, .25f) * grenadeSpeed;
        }
        GetComponent<Animator>().SetTrigger("Shoot");
    }

    /* ----------------------
     * Helper Functions
     ----------------------- */
    public void setPrimaryWeapon(int newPrimaryWeapon)
    {
        this.primaryWeapon = newPrimaryWeapon;
    }
}
