using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth.OnPlayerDeath += ResetLevel;
    }

    void ResetLevel()
    {
        FindObjectOfType<LevelLoader>().StartTransition(SceneManager.GetActiveScene().name);
    }
}
