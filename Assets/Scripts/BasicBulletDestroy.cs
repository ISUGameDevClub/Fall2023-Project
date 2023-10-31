using UnityEngine;

public class BasicBulletDestroy : MonoBehaviour
{
    //Make sure that this works with the EnemyController.cs (Assets\Scripts\EnemyController.cs) script (Talk with Michael Tunberg) - C
    [SerializeField] int damage;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Enemy")
        {
        //                insert title of enemy script
            other.GetComponent<EnemyController>().TakeDamage(damage);
            Destroy(gameObject);
        }
        else{
            Destroy(gameObject);
        }
        
    }


  
}
