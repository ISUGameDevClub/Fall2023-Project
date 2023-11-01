using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    [SerializeField] Vector2 speed;
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;
    private float textureUnitSizeX;
    public float autoPar;
    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
        SpriteRenderer[] sprite = GetComponentsInChildren<SpriteRenderer>();
        float width = 0;
        foreach (SpriteRenderer sr in sprite)
        {
            width += sr.sprite.texture.width / sr.sprite.pixelsPerUnit;
        }
        textureUnitSizeX = width;
    }
    private void LateUpdate()
    {
        Vector3 autoParVec3 = new Vector3(autoPar * Time.time, 0, 0);
        Vector3 deltaMovement = (autoParVec3 + cameraTransform.position) - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * speed.x, deltaMovement.y * speed.y, 0);
        lastCameraPosition = (autoParVec3 + cameraTransform.position);

        if (Mathf.Abs((autoParVec3.x + cameraTransform.position.x) - transform.position.x) >= textureUnitSizeX)
        {
            float offsetPositionX = ((autoParVec3.x + cameraTransform.position.x) - transform.position.x) % textureUnitSizeX;
            transform.position = new Vector3((autoParVec3.x + cameraTransform.position.x) + offsetPositionX, transform.position.y);
        }
    }
}
