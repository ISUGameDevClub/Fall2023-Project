using UnityEngine;

public class TransitionCollider : MonoBehaviour
{
    //seems cool beans, once you are finished get an exec to approve this if its not me-c
    [SerializeField] GameObject levelLoader;
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if(trigger.gameObject.tag == "Player")
        {
        levelLoader.GetComponent<LevelLoader>().LoadNextLevel();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
