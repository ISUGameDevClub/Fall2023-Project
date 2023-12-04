using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 5;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<CurrencyCount>().AddAmount(coinValue);
            GetComponent<Animator>().SetTrigger("CollectCoin");
            //PLAY SFX
        }
    }

    public void DestroyCoin()
    {
        Destroy(gameObject);
    }
}
