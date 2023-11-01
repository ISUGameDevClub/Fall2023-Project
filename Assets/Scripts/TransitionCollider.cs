using UnityEngine;

public class TransitionCollider : MonoBehaviour
{
    public LevelLoader levelLoader;
    public string levelToLoad;

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if(trigger.gameObject.tag.Equals("Player"))
        {
            levelLoader.StartTransition(levelToLoad);
        }
    }
}
