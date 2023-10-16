using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    //make a prefab that this works on, currently since it is disabled it cannot access the script to enable itself, should be easily fixed-c
    public static bool GameIsPaused = false;

    public GameObject pauseMenu;
    public GameObject pause;
    public GameObject options;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        pause.SetActive(true);
        options.SetActive(false);
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        //ZA WARUDO!!!
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitGame()
    {
        Debug.Log("NOOOOO! PLEASE DON'T GO!!! I DON'T KNOW WHAT I'LL DO WITHOUT YOU!!!");
        SceneManager.LoadScene("MainMenuTest");
    }

    public void OptionsMenu()
    {
        pause.SetActive(false);
        options.SetActive(true);
    }
}
