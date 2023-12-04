using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AutoscrollCamera : MonoBehaviour
{
    public float scrollSpeed = 0.025f;

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = new Vector3((transform.position.x + scrollSpeed), 
            transform.position.y, transform.position.z);
     }
}
