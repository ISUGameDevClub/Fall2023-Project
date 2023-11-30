using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    [SerializeField] float destroyTime = 2f;
    [SerializeField] int damage = 1;
    // Update is called once per frame

    public void FireBullet(EnemyController.enemySelection selection)
    {
        EnemyController.enemySelection es = selection;
        switch (es)
        {
            case EnemyController.enemySelection.enemy2:
                {
                    Destroy(gameObject, destroyTime);
                    break;
                }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerHealth>())
        {
            collision.gameObject.GetComponent<PlayerHealth>().DamagePlayer(damage, Vector3.zero);
        }
    }
}
