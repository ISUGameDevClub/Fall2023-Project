using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth_Demo : MonoBehaviour, IDamageable_Demo
{
    [SerializeField]
    private float health;
    
    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            health = 0;
            OnDeath();
        }
    }

    private void OnDeath()
    {

    }
}
