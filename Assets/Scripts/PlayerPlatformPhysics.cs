using UnityEngine;


public class PlayerPlatformPhysics : MonoBehaviour
{
    //create a temp gameobject private variable
    //store the collision game object to the temp gameobject variable on collision
    //add a boolean that is "onPlatform"
    //add an EarlyUpdate method that sets the parent of the temp gameobject to this transform when the boolean is true, set it to null when the bolean is false
    //set that boolean in the collisions instead
    //-c

    private GameObject tempObject;
    bool _onPlatform = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            tempObject = collision.gameObject;
            collision.gameObject.transform.SetParent(transform);
            _onPlatform = true;
        }
    }
    public bool IsOnPlatform()
    {
        return _onPlatform;
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);
            _onPlatform = false;
        }
    }
}
