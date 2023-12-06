using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryUnlockAlerter : MonoBehaviour
{
    [SerializeField] public GameObject daggerUnlockText;
    [SerializeField] public GameObject grenadeLauncherText;

    private void Start()
    {
        if (GameManager.bossDefeatedCount == 1)
        {
            daggerUnlockText.SetActive(true);
        }
        if (GameManager.bossDefeatedCount == 2)
        {
            grenadeLauncherText.SetActive(true);
        }
    }
}
