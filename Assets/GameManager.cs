using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool wrathDefeated = false;
    public static bool greedDefeated = false;
    public static bool gluttonyDefeated = false;

    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth.OnPlayerDeath += ResetLevel;
    }

    void ResetLevel()
    {
        FindObjectOfType<LevelLoader>().StartTransition(SceneManager.GetActiveScene().name);
    }

    public static bool CheckIfAllDefeated()
    {
        if(wrathDefeated && greedDefeated && gluttonyDefeated)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
