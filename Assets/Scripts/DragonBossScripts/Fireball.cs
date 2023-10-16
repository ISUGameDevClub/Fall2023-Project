using UnityEngine;

public class Fireball : MonoBehaviour
{
    private GameObject player;
    private Vector3 initialDirection;
    private float destroyTime = 10f;
    private Rigidbody2D rb;
    public float speed = 5f;

    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerMovement>().gameObject;
        rb = GetComponent<Rigidbody2D>();
        Vector2 initialDir = player.transform.position - this.transform.position;
        rb.velocity = initialDir * speed;
        Destroy(gameObject, destroyTime);
    }
}
