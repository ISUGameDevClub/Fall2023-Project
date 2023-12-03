using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallexBackground : MonoBehaviour
{
    private float length, startpos;
    private GameObject cam;
    public float parallaxEffect;

    private void Start()
    {
        cam = FindObjectOfType<Camera>().gameObject;
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if(temp > startpos + length)
        {
            startpos += length;
        }
        else if(temp < startpos - length)
        {
            startpos -= length;
        }
    }
}
