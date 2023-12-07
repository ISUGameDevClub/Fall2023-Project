using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBossAnimHelper : MonoBehaviour
{
    private SFXController sfxController;
    private DragonBossAttacks dragonBossAttacks;

    // Start is called before the first frame update
    void Start()
    {
        sfxController = FindObjectOfType<SFXController>();
        dragonBossAttacks = GetComponentInParent<DragonBossAttacks>();
    }

    public void SetAttackingFalse()
    {
        dragonBossAttacks.SetAttackingFalse();
    }

    public void SpawnFireballs()
    {
        StartCoroutine(dragonBossAttacks.SpawnFireballs());

    }

    public void LaserSound()
    {
        sfxController.playSound(4);
    }

    public void SwipeSound()
    {
        sfxController.playSound(20);
    }
}
