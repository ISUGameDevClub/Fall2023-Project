using UnityEngine;

public class MeleeColliderDetect : MonoBehaviour
{
    //what is the difference between this and the basic bullet destroy? can we not just use one script for this-c
   public int damage;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<TempEnemyScript>().TakeDamage(damage);
            Debug.Log("melee collision detected");
        }
    }
}
