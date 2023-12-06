using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool wrathDefeated = false;
    public static bool greedDefeated = false;
    public static bool gluttonyDefeated = false;

    public static int bossDefeatedCount = 0;

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
        bossDefeatedCount++;
        if(bossDefeatedCount == 1)
        {
            PlayerAttack.hasDagger = true;
        }
        if(bossDefeatedCount == 2)
        {
            PlayerAttack.hasGrenadeLauncher = true;
        }

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
