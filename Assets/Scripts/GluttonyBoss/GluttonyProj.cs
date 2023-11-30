using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GluttonyProj : MonoBehaviour
{
public Vector2 targetPosition; // Target position for the arc motion.
    public float arcHeight = 2.0f; // Adjust this value to control the height of the arc.
    public float speed = 5.0f;

    private Vector2 initialPosition;
    private float journeyLength;
    private float startTime;

    private bool isMoving = true;

    private void Start()
    {
        initialPosition = transform.position;
        journeyLength = Vector2.Distance(initialPosition, targetPosition);
        startTime = Time.time;
    }

    private void Update()
    {
        if (isMoving)
        {
            float distanceCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distanceCovered / journeyLength;

            if (fractionOfJourney < 1.0f)
            {
                float yOffset = Mathf.Sin(fractionOfJourney * Mathf.PI) * arcHeight;
                Vector2 newPosition = Vector2.Lerp(initialPosition, targetPosition, fractionOfJourney) + new Vector2(0, yOffset);

                transform.position = newPosition;
            }
            else
            {
                // Ensure the object reaches the target position.
                Destroy(gameObject);
                transform.position = targetPosition;
                isMoving = false;
            }
        }
    }
}
