using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreedAnimHelper : MonoBehaviour
{
    public GreedBoss greedBossAttacks;

    // Start is called before the first frame update
    void Start()
    {
        greedBossAttacks = GetComponentInParent<GreedBoss>();
    }

    public void ThrowCard()
    {

    }
}
