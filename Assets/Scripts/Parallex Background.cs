using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallexBackground : MonoBehaviour
{
    [SerializeField] private float parallexEffectMultiplier = 0.5f;
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }

    private void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position = lastCameraPosition;
        float parallexEffectMultiplier = 0.5f;
        transform.position += deltaMovement * parallexEffectMultiplier;
        lastCameraPosition = cameraTransform.position;
    }
}
