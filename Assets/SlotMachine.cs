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
        Debug.Log("Spinning Slots");
        isSpinning = true;
        slotAnims.SetTrigger("Spin");
    }

    public void SpinStopAnim()
    {
        Debug.Log("Stopping Spin");
        isSpinning = false;
        int randomSlot = Random.Range(1, 4);
        slotAnims.SetInteger("Result", randomSlot);
    }

    public void SpawnDiamonds()
    {
        //Instantiate the attack
        Debug.Log("Spawning Diamonds");
    }

    public void SpawnCherries()
    {
        //Instantiate the attack
        Debug.Log("Spawning Cherries");
    }

    public void SpawnCoinsGems()
    {
        //Instantiate the attack
        Debug.Log("Spawning Coins and Gems");
    }
}
