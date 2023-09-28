using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour
{
    private int soundCount;
    private AudioClip[] soundArray;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //to-do: make soundCount dynamicly set
        soundCount = 5;

        soundArray = new AudioClip[soundCount];
    }

    int playSound(int soundIndex, float volumeScale)
    {
        //Do we have a sound?
        if(soundIndex < 0 || soundIndex >= soundCount)
        {
            //No, we don't!
            print("ERROR: SFXController: soundIndex is out of range. No sound played.\n");
            return 0;
        }

        //play the sound
        audioSource.PlayOneShot(soundArray[soundIndex], volumeScale);

        print("SFXController: sound" + soundIndex +" has been played.\n");
        return 1;
    }

}
