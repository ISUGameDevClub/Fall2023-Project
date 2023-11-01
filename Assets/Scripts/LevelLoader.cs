using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    private Animator loadAnimator;
    public string targetScene;

    public void Start()
    {
        loadAnimator = GetComponentInChildren<Animator>();
    }

    public void StartTransition(string levelToLoad)
    {
        if(targetScene.Equals(""))
        {
            targetScene = levelToLoad;
        }
        loadAnimator.SetTrigger("Start");
    }

    public void ChangeSceneEvent()
    {
        SceneManager.LoadScene(targetScene);
    }

    public void ExitGame()
    {
        Debug.Log("Exited game");
        Application.Quit();
    }
}
