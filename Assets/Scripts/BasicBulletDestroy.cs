using UnityEngine;

public class BasicBulletDestroy : MonoBehaviour
{
    [SerializeField] int damage;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.GetComponent<EnemyController>())
        {
            other.GetComponent<EnemyController>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
