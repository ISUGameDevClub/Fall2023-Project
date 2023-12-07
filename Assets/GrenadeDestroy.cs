using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeDestroy : MonoBehaviour
{
    private SFXController sfxController;
    public GameObject explosion;
    void Start()
    {
        sfxController = FindObjectOfType<SFXController>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.GetComponent<Coin>() && !other.GetComponent<HealthPickup>() && !other.GetComponent<FunctionTrigger>())
        {
            sfxController.playSound(8);
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
