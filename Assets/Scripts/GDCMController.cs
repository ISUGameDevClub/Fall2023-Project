using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GDCMController : MonoBehaviour
{
    [System.Serializable]
    public class Song
    {
        public AudioClip introClip;  // Intro audio clip (played once before looping)
        public AudioClip loopClip;   // Looping audio clip
        public float volume;         // Volume of the song (default is full volume)
    }
    
    private static GDCMController instance;

    public AudioSource gameMusic;
    public Song[] songs;
    private Song newSong;
    private Song currentSong;
    public float swapSpeed;

    void Awake()
    {
        newSong = songs[0];
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
        // Check if should start looping
        if (!gameMusic.isPlaying && gameMusic.clip == currentSong.introClip && currentSong.loopClip)
        {
            StartLooping();
        }

        CrossfadeMusic();
        //DEMO MUSIC, CHANGE TO ACTUAL SCENES WHEN READY
        if (SceneManager.GetActiveScene().name.Equals("0MainMenu"))
        {
            ChangeSong(0);
        }
        if (SceneManager.GetActiveScene().name.Equals("2LevelSelect"))
        {
            ChangeSong(3);
        }
        if (SceneManager.GetActiveScene().name.Equals("2DemoWrathLevel"))
        {
            ChangeSong(6);
        }
        if (SceneManager.GetActiveScene().name.Equals("BossWrath"))
        {
            ChangeSong(8);
        }
        if (SceneManager.GetActiveScene().name.Equals("BossGluttony"))
        {
            ChangeSong(5);
        }
        if (SceneManager.GetActiveScene().name.Equals("BossGreed"))
        {
            ChangeSong(4);
        }
        if (SceneManager.GetActiveScene().name.Equals("3FinalCredits"))
        {
            ChangeSong(7);
        }
        if (SceneManager.GetActiveScene().name.Equals("1Credits"))
        {
            ChangeSong(7);
        }
        if (SceneManager.GetActiveScene().name.Equals("TutorialLevel"))
        {
            ChangeSong(2);
        }
        if (SceneManager.GetActiveScene().name.Equals("WrathLevel"))
        {
            ChangeSong(6);
        }
        if (SceneManager.GetActiveScene().name.Equals("GluttonyLevel"))
        {
            ChangeSong(6);
        }
        if (SceneManager.GetActiveScene().name.Equals("GreedLevel"))
        {
            ChangeSong(1);
        }
    }

    public void ChangeSong(int soundtrackIndex)
    {
        newSong = songs[soundtrackIndex];
    }

    private void StartLooping()
    {
        gameMusic.loop = true;
        gameMusic.clip = currentSong.loopClip;
        gameMusic.Play();
    }
    private void StartIntro()
    {
        gameMusic.loop = false;
        gameMusic.clip = currentSong.introClip;
        gameMusic.Play();
    }

    public void CrossfadeMusic()
    {
        if (currentSong != newSong)
        {
            if (gameMusic.volume > .05f)
            {
                gameMusic.volume -= Time.unscaledDeltaTime * swapSpeed;
            }
            else
            {
                currentSong = newSong;
                gameMusic.volume = 0;
                if (currentSong.introClip) {
                    StartIntro();
                }
                else {
                    StartLooping();
                }
            }
        }
        else
        {
            if (gameMusic.volume < currentSong.volume)
            {
                gameMusic.volume += Time.unscaledDeltaTime * swapSpeed;
            }
            else
            {
                gameMusic.volume = currentSong.volume;
            }
        }
    }
}
