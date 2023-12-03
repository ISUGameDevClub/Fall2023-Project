using UnityEngine;

public class BasicBulletDestroy : MonoBehaviour
{
    [SerializeField] int damage;

    public bool destroyAfterTime = false;
    public float destroyTimer = 10f;

    private void Update()
    {
        destroyTimer -= Time.deltaTime;
        if(destroyTimer <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.GetComponent<EnemyController>())
        {
            other.GetComponent<EnemyController>().TakeDamage(damage);
        }
        if (other.CompareTag("WrathBoss"))
        {
            //Not sure if this is the proper place we're handling hurting enemies...
            other.GetComponentInParent<DragonBossHealth>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
