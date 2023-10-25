using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraTrack : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private Boolean useStartingOffset;

    [SerializeField]
    private Vector3 cameraOffset;

    private enum trackingBehaviour
    {
        TrackX
    }

    [SerializeField]
    private trackingBehaviour trackBehaviour;

    private void Awake()
    {
        if (useStartingOffset)
        {
            cameraOffset = this.transform.position - target.position;
        }
    }

    private void LateUpdate()
    {
        switch (trackBehaviour)
        {
            case trackingBehaviour.TrackX:
                this.transform.position = new Vector3(target.position.x + cameraOffset.x, this.transform.position.y, this.transform.position.z);
                break;
        }
    }
}
