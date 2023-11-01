using UnityEngine;

public class SFXController : MonoBehaviour
{
    private int soundCount;
    [SerializeField] AudioClip[] soundArray;
    [SerializeField] GameObject soundSource;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void spawnSound(int soundIndex)
    {
        //make the opject to play the sound
        GameObject soundObject = Instantiate(soundSource);
        //play a sound
        soundObject.GetComponent<AudioSource>().PlayOneShot(soundArray[soundIndex]);
        //destory the object
        Destroy(soundObject, soundArray[soundIndex].length + 1);
    }

    public int playSound(int soundIndex)
    {
        //Do we have a sound?
        if(soundIndex < 0 || soundIndex >= soundArray.Length)
        {
            //No, we don't!
            print("ERROR: SFXController: playSound(): soundIndex is out of range. No sound played.\n");
            return 0;
        }

        //play the sound
        spawnSound(soundIndex);

        print("SFXController: playSound(): sound" + soundIndex +" has been played.\n");
        return 1;
    }
}
