using UnityEngine;

public class TempEnemyScript : MonoBehaviour
{
    //we can remove this and start using the actual enemy controller now
    [SerializeField] int maxHealth = 5;
    [SerializeField] int currentHealth;
    
    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        EnemyDeath();
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
