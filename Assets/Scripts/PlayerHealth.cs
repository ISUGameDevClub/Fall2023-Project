using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    
    public int playerHealth;
    GameObject healthUI;
    [SerializeField] private int playerMaxHealth = 100;
    public delegate void PlayerDeathEventHandler();
    public event PlayerDeathEventHandler OnPlayerDeath;
    // Start is called before the first frame update
    void Start()
    {
        healthUI = GameObject.Find("Health");
        playerHealth = playerMaxHealth;
    }

    public void DamagePlayer(int damagePoint) {
        healthUI.GetComponent<UIHealth>().ReduceHealth();
        playerHealth -= damagePoint;
        if (playerHealth <= 0) {
            // Kill player Function Here
            OnPlayerDeath();
        }
    }

    public void HealPlayer(int healPoint) {
        healthUI.GetComponent<UIHealth>().ReduceHealth();
        playerHealth += healPoint;
        if (playerHealth > playerMaxHealth){
            playerHealth = playerMaxHealth;
        }
    }

    public void SetPlayerHealth(int newHealth) {
        playerHealth = newHealth;
    }
}
