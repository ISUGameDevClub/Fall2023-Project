using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth = 3;
    public int playerHealth;
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
