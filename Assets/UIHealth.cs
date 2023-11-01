using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHealth : MonoBehaviour
{
    [SerializeField] GameObject[] healthIndis;
    int healthInc;
    // Start is called before the first frame update
    void Start()
    {
        healthInc = healthIndis.Length-1;
    }
    public void ReduceHealth(){
        if(healthInc<0)return;
        healthIndis[healthInc].SetActive(false);
        healthInc--;
    }
    public void IncreaseHealth(){
        if(healthInc>=4)return;
        healthInc++;
        healthIndis[healthInc].SetActive(true);
    }
}
