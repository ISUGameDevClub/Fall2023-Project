using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;
    [SerializeField] int targetScene;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Slash))
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(targetScene));
    }

    IEnumerator LoadLevel(int leveLIndex)
    {
        //Play transition animation
        transition.SetTrigger("Start");

        //Wait for animation
        yield return new WaitForSeconds(transitionTime);

        //Load the scene
        SceneManager.LoadScene(leveLIndex);

    }
}
