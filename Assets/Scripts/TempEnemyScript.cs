using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempEnemyScript : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;
    
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    void EnemyDeath()
    {
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
