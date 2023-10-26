using UnityEngine;

public class LaunchPad : MonoBehaviour
{
   
    public float bounce = 20f;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
        }
    }
    // Start is called before the first frame update
    
}
