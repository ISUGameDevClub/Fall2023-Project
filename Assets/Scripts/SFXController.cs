using UnityEngine;

public class SFXController : MonoBehaviour
{
    //ask execs if you have any issues, otherwise once you finish grab one of us and be ready to test it-c
    private int soundCount;
    [SerializeField] AudioClip[] soundArray;
    [SerializeField] GameObject soundSource;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        //NOTE: Put sounds into SFXManager object
        soundCount = 0;
        soundArray = new AudioClip[soundCount];
    }

    private void spawnSound(int soundIndex, float volumeScale)
    {
        //make the opject to play the sound
        GameObject soundObject = Instantiate(soundSource);
        //play a sound
        soundObject.GetComponent<AudioSource>().PlayOneShot(soundArray[soundIndex], volumeScale);
        //destory the object
        Object.Destroy(soundObject, soundArray[soundIndex].length + 1);
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
        spawnSound( soundIndex, volumeScale);

        print("SFXController: playSound(): sound" + soundIndex +" has been played.\n");
        return 1;
    }
}
