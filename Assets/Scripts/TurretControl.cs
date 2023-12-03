using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTemp : MonoBehaviour
{
    [SerializeField] public GameObject shoot;
    [SerializeField] public Transform shootTransform;
    int shootDirection;
    private bool canFire;
    [SerializeField] float timer;
    [SerializeField] float timeBetweenFire;
    private Rigidbody2D rb;
    public float force;
    [SerializeField] bool isRight;
    [SerializeField] bool isAbove;
    Vector2 turretAim;
    // Start is called before the first frame update
    void Start()
    {
        if (shootDirection == 1)
        {
            turretAim = new Vector2(-1, -1);
        }
        if (shootDirection == 2)
        {
            turretAim = new Vector2(-1, 0);
        }
        if (shootDirection == 3)
        {
            turretAim = new Vector2(-1, 1);
        }
        if (shootDirection == 4)
        {
            turretAim = new Vector2(0, 1);
        }
        if (shootDirection == 5)
        {
            turretAim = new Vector2(1, 1);
        }
        if (shootDirection == 6)
        {
            turretAim = new Vector2(1, 0);
        }
        if (shootDirection == 7)
        {
            turretAim = new Vector2(1, -1);
        }

        if (!isRight)
        {
            force *= -1;
        }
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeBetweenFire)
        {
            canFire = true;
            timer = 0;
            GameObject temporaryObject = Instantiate(shoot, shootTransform.position, Quaternion.identity);
            rb = temporaryObject.GetComponent<Rigidbody2D>();
            rb.velocity = turretAim.normalized * force;
        }
    }
}
