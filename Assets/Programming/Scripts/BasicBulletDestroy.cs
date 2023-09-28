using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBulletDestroy : MonoBehaviour
{
    float timeActive = 0;
    public float desiredTimeActive;


    void Update()
    {
        DestroyAfterTime();
    }

    //Destroys object after desired amount of active time
    void DestroyAfterTime()
    {
        timeActive += Time.deltaTime;
        if(timeActive > desiredTimeActive)
        {
            Destroy(gameObject);
        }
    }
}
