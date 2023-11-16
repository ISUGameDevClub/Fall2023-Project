using UnityEngine;

public class BasicBulletDestroy : MonoBehaviour
{
    [SerializeField] int damage;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.GetComponent<EnemyController>())
        {
            other.GetComponent<EnemyController>().TakeDamage(damage);
        }
        if (other.CompareTag("WrathBoss"))
        {
            //Not sure if this is the proper place we're handling hurting enemies...
            Debug.Log("TRIGGER");
            other.GetComponentInParent<DragonBossHealth>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
