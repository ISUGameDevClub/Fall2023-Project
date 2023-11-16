using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBossAnimHelper : MonoBehaviour
{
    private DragonBossAttacks dragonBossAttacks;

    // Start is called before the first frame update
    void Start()
    {
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


}
