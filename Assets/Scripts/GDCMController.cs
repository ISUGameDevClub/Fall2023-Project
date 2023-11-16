using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GDCMController : MonoBehaviour
{
    private static GDCMController instance;

    public AudioSource gameMusic;
    public AudioClip[] soundtracks;
    private AudioClip newClip;
    public float musicVolume = .2f;
    public float swapSpeed = .5f;

    void Awake()
    {
        newClip = gameMusic.clip;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        //DELETE THIS WHEN DONE GIAN
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }    

        CrossfadeMusic();
        //DEMO MUSIC, CHANGE TO ACTUAL SCENES WHEN READY
        if (SceneManager.GetActiveScene().name.Equals("0DemoMenu"))
        {
            ChangeSong(0);
        }
        if (SceneManager.GetActiveScene().name.Equals("1DemoLevelSelect"))
        {
            ChangeSong(0);
        }
        if (SceneManager.GetActiveScene().name.Equals("2DemoWrathLevel"))
        {
            ChangeSong(1);
        }
        if (SceneManager.GetActiveScene().name.Equals("3DemoWrathBoss"))
        {
            ChangeSong(2);
        }
        if (SceneManager.GetActiveScene().name.Equals("4DemoEnd"))
        {
            ChangeSong(0);
        }
    }

    public void ChangeSong(int soundtrackIndex)
    {
        newClip = soundtracks[soundtrackIndex];
    }

    public void CrossfadeMusic()
    {
        if (gameMusic.clip != newClip)
        {
            if (gameMusic.volume > .05f)
            {
                gameMusic.volume -= Time.unscaledDeltaTime * swapSpeed;
            }
            else
            {
                gameMusic.volume = 0;
                gameMusic.clip = newClip;
                gameMusic.Play();
            }
        }
        else
        {
            if (gameMusic.volume < musicVolume)
            {
                gameMusic.volume += Time.unscaledDeltaTime * swapSpeed;
            }
            else
            {
                gameMusic.volume = musicVolume;
            }
        }
    }
}
