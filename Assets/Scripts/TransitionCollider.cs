using UnityEngine;

public class TransitionCollider : MonoBehaviour
{
    public string nextScene;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            FindObjectOfType<LevelLoader>().StartTransition(nextScene);
        }
    }
}
