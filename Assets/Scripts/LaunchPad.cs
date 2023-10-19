using UnityEngine;

public class LaunchPad : MonoBehaviour
{
    //Make sure that everything is possible to be edited by the level design team in inspector-c
    private float bounce = 20f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
        }
    }
    // Start is called before the first frame update
    
}
