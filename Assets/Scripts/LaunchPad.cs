using UnityEngine;

public class LaunchPad : MonoBehaviour
{
    //Make sure that everything is possible to be edited by the level design team in inspector-c
    [SerializeField] private float bounce = 1.2f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.GetComponent<ContraEnemyController>())
        {
            GetComponent<Animator>().SetTrigger("Bounce");
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
            Debug.Log("Launched");
        }
    }
    // Start is called before the first frame update
    
}
