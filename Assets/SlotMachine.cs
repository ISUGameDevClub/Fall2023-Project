using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachine : MonoBehaviour
{
    private SFXController sfxController;

    private Animator slotAnims;
    private GameObject player;
    public bool isSpinning = false;

    //Slot Machine Attacks
    public GameObject diamondAttack;
    public GameObject cherryAttack;
    public GameObject coingemsAttack;

    public void Start()
    {
        slotAnims = GetComponent<Animator>();
        sfxController = FindObjectOfType<SFXController>();
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    public void SpinSlots()
    {
        slotAnims.SetTrigger("Spin");
        sfxController.playSound(25);
    }

    public void SpinStopAnim()
    {
        Debug.Log("Stopping Spin");
        isSpinning = false;
        int randomSlot = Random.Range(1, 4);
        slotAnims.SetInteger("Result", randomSlot);
        sfxController.playSound(26);
    }

    public void SpawnDiamonds()
    {
        //Instantiate the attack
        Debug.Log("Spawning Diamonds");
        Instantiate(diamondAttack, 
            player.transform.position + new Vector3(0, 20, 0), 
            Quaternion.identity);
    }

    public void SpawnCherries()
    {
        //Instantiate the attack
        Instantiate(diamondAttack,
            player.transform.position + new Vector3(0, 20, 0),
            Quaternion.identity);
    }

    public void SpawnCoinsGems()
    {
        //Instantiate the attack
        Instantiate(diamondAttack,
            player.transform.position + new Vector3(0, 20, 0),
            Quaternion.identity);
        Debug.Log("Spawning Coins and Gems");
    }
}
