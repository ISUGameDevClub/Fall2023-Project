using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public bool shopActive;

    private static bool megaShotSoldOut = false;
    public TMP_Text megaShotText;
    private static bool railgunSoldOut = false;
    public TMP_Text railgunText;

    //Tutorial Text on first buy
    public GameObject railgunTutorial;
    public GameObject megaShotTutorial;

    public int healthCost = 10;
    public int damageCost = 20;
    public int megaShotCost = 35;
    public int railgunCost = 75;

    private bool damageBoostEnabled = false;
    private float damageBoostTimer = 0f;
    public float damageBoostTime = 60f;

    [SerializeField] BoxCollider2D shopTrigger;
    [SerializeField] GameObject ShopVisible;

    // Start is called before the first frame update
    void Start()
    {
        shopActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (shopActive == true)
        {
            ShopVisible.SetActive(true);
            FindObjectOfType<UICurrency>().ShowCurrency();
        }
        else
        {
            ShopVisible.SetActive(false);
        }

        //Damage Boost
        if(damageBoostEnabled)
        {
            damageBoostTimer -= Time.deltaTime;
            if(damageBoostTimer <= 0)
            {
                damageBoostEnabled = false; 
                GameObject.Find("DoubleDamagePanel").GetComponentInChildren<Image>().enabled = false;
                GameObject.Find("DoubleDamagePanel").GetComponentInChildren<TMP_Text>().enabled = false;
                foreach (EnemyController enemy in FindObjectsOfType<EnemyController>())
                {
                    enemy.takeExtraDamage = false;
                }
            }
        }

        //Sold Out Seconaries/Primaries
        if(megaShotSoldOut)
        {
            megaShotText.text = "Sold Out!";
        }
        if(railgunSoldOut)
        {
            railgunText.text = "Sold Out!";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (shopActive == false && collision.gameObject.tag == "Player")
        {
            shopActive = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (shopActive == true && collision.gameObject.tag == "Player")
        {
            shopActive = false;
        }
    }

    public void PurchaseHealth()
    {
        if(FindObjectOfType<CurrencyCount>().GetAmount() >= healthCost)
        {
            if(!FindObjectOfType<PlayerHealth>().GetPlayerHasPotion())
            {
                FindObjectOfType<CurrencyCount>().RemoveAmount(healthCost);
                FindObjectOfType<PlayerHealth>().SetPlayerHasPotion(true);
            }
        }
    }

    public void PurchaseDamageBoost()
    {
        if (FindObjectOfType<CurrencyCount>().GetAmount() >= damageCost)
        {
            if(!damageBoostEnabled)
            {
                damageBoostEnabled = true;
                GameObject.Find("DoubleDamagePanel").GetComponentInChildren<Image>().enabled = true;
                GameObject.Find("DoubleDamagePanel").GetComponentInChildren<TMP_Text>().enabled = true;
                damageBoostTimer = damageBoostTime;
                foreach(EnemyController enemy in FindObjectsOfType<EnemyController>())
                {
                    enemy.takeExtraDamage = true;
                }
            }
        }
    }

    public void PurchaseRailgun()
    {
        if (FindObjectOfType<CurrencyCount>().GetAmount() >= railgunCost)
        {
            if(!railgunSoldOut)
            {
                FindObjectOfType<CurrencyCount>().RemoveAmount(railgunCost);
                StyleSystem.hasRailgun = true;
                railgunSoldOut = true;
                Instantiate(railgunTutorial, 
                    FindObjectOfType<PlayerMovement>().gameObject.transform.position, 
                    Quaternion.identity);
            }
        }
    }

    public void PurchaseMegaShot()
    {
        if (FindObjectOfType<CurrencyCount>().GetAmount() >= megaShotCost)
        {
            if(!megaShotSoldOut)
            {
                FindObjectOfType<CurrencyCount>().RemoveAmount(megaShotCost);
                PlayerAttack.hasMegaShot = true;
                megaShotSoldOut = true;
                Instantiate(megaShotTutorial,
                    FindObjectOfType<PlayerMovement>().gameObject.transform.position,
                    Quaternion.identity);
            }
        }
    }
}
