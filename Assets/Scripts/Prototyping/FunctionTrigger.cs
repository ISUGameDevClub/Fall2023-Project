using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FunctionTrigger : MonoBehaviour
{
    public UnityEvent functionTrigger;

    public GameObject targetObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == targetObject)
        {
            functionTrigger.Invoke();
        }
    }
}
