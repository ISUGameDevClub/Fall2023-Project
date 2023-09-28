using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{
    //List of booleans to track what checkpoints are marked
    List<bool> checkpoints = new List<bool>();

    private void Awake()
    {
        //Array of GameObjects to find all of the checkpoints in the scene on awake
        GameObject[] checkpoints;

        //All Checkpoints must be tagged as a Checkpoint
        checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");

        //For loop to add all checkpoints from the checkpoints
        //array into the list as false booleans to await being set to true when passing a checkpoint
        for(int i=0;i<checkpoints.Length; i++) {
            this.checkpoints.Add(false);
        }  
    }
    class SavePoint
    {
        private GameObject currentSave;
        private GameObject previousSave;
        void SetSave(GameObject save)
        {
            if (currentSave != null)
            {
                previousSave = currentSave;
                currentSave = save;
            }
            else
            {
                currentSave = save;
            }
        }
    }
}
