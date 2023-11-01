using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerScript : MonoBehaviour
{
    [SerializeField]
    private LayerMask piercingLayers;

    [SerializeField]
    private LayerMask blockingLayers;

    [SerializeField, Range(0, 100)]
    private float maxLazerRange;

    [SerializeField]
    private SpriteRenderer beamStart;

    [SerializeField]
    private SpriteRenderer beamExpanding;

    [SerializeField]
    private Transform emissionTransform;

    [SerializeField]
    private int beamDamage;


    // Ratio for converting beamStart scale to Unity Units.
    //[SerializeField]
    private float beamStartUnitRatio = 0.6875f;

    // Ratio for converting beamExpanding scale to Unity Units.
    //[SerializeField]
    private float beamExpandingUnitRatio = 1f;

    private void FixedUpdate()
    {
        float piercingCastRange = maxLazerRange;

        // Raycast to find a blocking object
        RaycastHit2D blockingHit = Physics2D.Raycast(emissionTransform.position, this.transform.up, maxLazerRange, blockingLayers.value);
        // If nothing was hit to block the lazer.
        if (!blockingHit)
        {
            beamStart.size = new Vector2(beamStart.size.x, 1);
            beamExpanding.size = new Vector2(beamExpanding.size.x, maxLazerRange);
        }
        else{
            // We don't want our lazer to pierce through a blocking object.
            piercingCastRange = blockingHit.distance;

            // Trigger damage method on hit object if suitable
            PlayerHealth playerHealth = blockingHit.collider.GetComponent<PlayerHealth>();
            if(playerHealth){
                playerHealth.DamagePlayer(beamDamage, blockingHit.point);
            }

            // Update lazer beam visuals
            if(blockingHit.distance <= beamStartUnitRatio){
                beamStart.size = new Vector2(beamStart.size.x, blockingHit.distance);
                beamExpanding.size = new Vector2(beamExpanding.size.x, 0);
            }
            else{
                beamStart.size = new Vector2(beamStart.size.x, 1);
                // The distance we need to cover with the expanding portion of the lazer beam
                // float distanceToCover = blockingHit.distance - beamStartUnitRatio;
                float distanceToCover = blockingHit.distance - 0.61f;
                beamExpanding.size = new Vector2(beamExpanding.size.x, distanceToCover * beamExpandingUnitRatio);
            }
        }

        // Raycast to find objects that can be pierced.
        RaycastHit2D[] piercingHits = Physics2D.RaycastAll(emissionTransform.position, this.transform.up, piercingCastRange, piercingLayers.value);
        for(int i = 0; i < piercingHits.Length; i++)
        {
            // Look for and trigger damage methods on suitable objects
            PlayerHealth playerHealth = piercingHits[i].collider.GetComponent<PlayerHealth>();
            if(playerHealth){
                playerHealth.DamagePlayer(beamDamage, piercingHits[i].point);
            }
        }

    }

}
