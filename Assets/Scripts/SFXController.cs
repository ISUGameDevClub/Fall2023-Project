using UnityEngine;

public class SFXController : MonoBehaviour
{
    //ask execs if you have any issues, otherwise once you finish grab one of us and be ready to test it-c
    private int soundCount;
    private AudioClip[] soundArray;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //to-do: make soundCount dynamicly set
        soundCount = 0;

        soundArray = new AudioClip[soundCount];
        
        //to_do: fill soundCount with sounds - doesn't seem like we have any sounds yet.
    }

    public int playSound(int soundIndex, float volumeScale)
    {
        //Do we have a sound?
        if(soundIndex < 0 || soundIndex >= soundCount)
        {
            //No, we don't!
            print("ERROR: SFXController: playSound(): soundIndex is out of range. No sound played.\n");
            return 0;
        }

        //play the sound
        audioSource.PlayOneShot(soundArray[soundIndex], volumeScale);

        print("SFXController: playSound(): sound" + soundIndex +" has been played.\n");
        return 1;
    }

    //dunno if we need this
    public void addSound(AudioClip newSound)
    {
        soundArray[soundCount] = newSound;
        soundCount++;
    }
}
