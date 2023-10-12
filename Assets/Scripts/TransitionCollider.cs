using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionCollider : MonoBehaviour
{
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
