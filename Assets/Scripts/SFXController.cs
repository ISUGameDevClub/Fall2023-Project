using UnityEngine;

public class SFXController : MonoBehaviour
{
    //ask execs if you have any issues, otherwise once you finish grab one of us and be ready to test it-c
    private int soundCount;
    private int typeCount;
    [SerializeField] AudioClip[] soundArray;
    [SerializeField] GameObject soundSource;
    [SerializeField] soundType[] soundTypes;


    // Start is called before the first frame update
    void Start()
    {
        //NOTE: Put sounds into SFXManager object
        soundCount = 0;
        typeCount = 0;
        soundArray = new AudioClip[soundCount];
        soundTypes = new soundType[typeCount];
    }

    private void spawnSound(int soundIndex, float volumeScale)
    {
        //make the opject to play the sound
        GameObject soundObject = Instantiate(soundSource);
        soundObject.AddComponent<AudioSource>();
        //play a sound
        soundObject.GetComponent<AudioSource>().PlayOneShot(soundArray[soundIndex], volumeScale);
        //destory the object
        Object.Destroy(soundObject, soundArray[soundIndex].length + 1);
    }

    //Old version, hold on to it til new one with object array is ready
    public int playSoundOld(int soundIndex, float volumeScale)
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
    //Old version, hold on to it til new one with object array is ready
    public int playRandSoundOld(float volumeScale)
    {
        int index = Random.Range(0, soundCount);

        //Do we have a sound?
        if (index < 0 || index >= soundCount)
        {
            //No, we don't!
            print("ERROR: SFXController: playRandSound(): index is out of range. No sound played.\n");
            return 0;
        }

        //play the sound
        spawnSound(index, volumeScale);

        print("SFXController: plaRandySound(): sound" + index + " has been played.\n");
        return 1;
    }




    public int playSound(int soundTypeIndex, int soundIndex, float volumeScale)
    {
        //Do we have a sound?
        if (soundIndex < 0 || soundIndex >= soundTypes[soundTypeIndex].soundArray.Length)
        {
            //No, we don't!
            print("ERROR: SFXController: playSound(): soundIndex is out of range. No sound played.\n");
            return 0;
        }
        //play the sound
        spawnSound(soundIndex, volumeScale);

        print("SFXController: playSound(): sound" + soundIndex + " has been played.\n");
        return 1;
    }

    public int playRandSound(int soundTypeIndex, float volumeScale)
    {
        int index = Random.Range(0, soundCount);

        //Do we have a sound?
        if (index < 0 || index >= soundCount)
        {
            //No, we don't!
            print("ERROR: SFXController: playRandSound(): index is out of range. No sound played.\n");
            return 0;
        }

        //play the sound
        spawnSound(index, volumeScale);

        print("SFXController: plaRandySound(): sound" + index + " has been played.\n");
        return 1;
    }
}

public class soundType : MonoBehaviour
{
    private int soundCount;
    public AudioClip[] soundArray;
    soundType()
    {
        soundCount = 0;
    }
}