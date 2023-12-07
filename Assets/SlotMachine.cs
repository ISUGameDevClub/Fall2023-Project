using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachine : MonoBehaviour
{
    private Animator slotAnims;
    public bool isSpinning = false;

    //Slot Machine Attacks
    public GameObject diamondAttack;
    public GameObject cherryAttack;
    public GameObject coingemsAttack;

    public void Start()
    {
        slotAnims = GetComponent<Animator>();
    }

    public void SpinSlots()
    {
        isSpinning = true;
        slotAnims.SetTrigger("Spin");
    }

    public void SpinStopAnim()
    {
        isSpinning = false;
        int randomSlot = Random.Range(1, 4);
        slotAnims.SetInteger("Result", randomSlot);
    }

    public void SpawnDiamonds()
    {
        //Instantiate the attack
    }

    public void SpawnCherries()
    {
        //Instantiate the attack
    }

    public void SpawnCoinsGems()
    {
        //Instantiate the attack
    }
}
