using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollAnim : MonoBehaviour
{
    Transform scrollTransform;
    [SerializeField] float scrollSpeed;
    [SerializeField] float stopPoint;
    [SerializeField] string yPosition; //for debug purposes
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        yPosition = transform.position.y.ToString(); //debug to find the y position, didn't allign with the object's transform tag
        if (transform.position.y > stopPoint)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - (Time.deltaTime * scrollSpeed));
        }
    }
}
