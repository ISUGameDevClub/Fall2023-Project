using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [Header("SFX")]
    private SFXController sfxController;

    public int coinValue = 5;

    void Start()
    {
        sfxController = FindObjectOfType<SFXController>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<CurrencyCount>().AddAmount(coinValue);
            GetComponent<Animator>().SetTrigger("CollectCoin");
            sfxController.playSound(14);
        }
    }

    public void DestroyCoin()
    {
        Destroy(gameObject);
    }
}
