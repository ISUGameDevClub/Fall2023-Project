using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] Animator transition;

    [SerializeField] float transitionTime = 1f;
    [SerializeField] string targetScene;


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

    IEnumerator LoadLevel(string leveLIndex)
    {
        //Play transition animation
        transition.SetTrigger("Start");

        //Wait for animation
        yield return new WaitForSeconds(transitionTime);

        //Load the scene
        SceneManager.LoadScene(leveLIndex);

    }
}
