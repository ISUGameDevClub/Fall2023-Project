using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class WaypointFinder : MonoBehaviour
{
            //We should change this to use the Rigidbody2D.MovePosition() method for movement rather than transform.position setting to eliminate physics bugs since we are using physics to move everything else
            //Make sure that it is easy to set waypoints by copying children waypoints from the prefab of the moving platform, and then set the parent transform of each waypoint to null so that it moves correctly
        //P.S. change this to fixed update because all rigidbody updating should be done in FixedUpdate(); -c

    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;

    private void Start(){
        foreach(GameObject point in waypoints){
            point.transform.parent=null;
        }
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;  
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);

    }
}
