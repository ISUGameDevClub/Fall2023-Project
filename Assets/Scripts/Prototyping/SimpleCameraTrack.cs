using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraTrack : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private float yTarget;

    [SerializeField]
    float cameraYSpeed;

    // Used for the smoothdamp function
    private float yDampVelocity = 0f;
    private float smoothTime;

    // What margin between y and target y is acceptable when doing a comparison?
    private float ydistanceMargin = 0.1f;

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
        yTarget = this.transform.position.y;
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
                this.transform.position = new Vector3(target.position.x + cameraOffset.x, calculateYPos(), this.transform.position.z);
                break;
        }
    }

    public void setYTarget(float target)
    {
        this.yTarget = target;
        smoothTime = Mathf.Abs((this.transform.position.y - yTarget) / cameraYSpeed);
        yDampVelocity = 0f;
    }

    // Function that tries to smoothly move the y position of the camera to yTarget.
    private float calculateYPos()
    {
        if(Mathf.Abs(this.transform.position.y - yTarget) < ydistanceMargin)
        {
            return yTarget;       
        }
        else
        {
            return Mathf.SmoothDamp(this.transform.position.y, yTarget, ref yDampVelocity, smoothTime, Mathf.Infinity, Time.deltaTime);
        }
        
    }
}
