using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTemp : MonoBehaviour
{
    [SerializeField] public GameObject shoot;
    [SerializeField] public Transform shootTransform;
    private bool canFire;
    [SerializeField] float timer;
    [SerializeField] float timeBetweenFire;
    private Rigidbody2D rb;
    public float force;
    [SerializeField] bool isRight;
    // Start is called before the first frame update
    void Start()
    {
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
            rb.velocity = new Vector2(1, 0).normalized * force;
        }
    }
}
