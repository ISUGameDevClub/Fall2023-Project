using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private Slider healthBar;
    public GameObject potionUIObject;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = playerHealth.maxHealth;
        healthBar.minValue = 0;
    }

    private void Update()
    {
        healthBar.value = playerHealth.getCurrentHealth();
        if(playerHealth.GetPlayerHasPotion())
        {
            potionUIObject.SetActive(true);
        }
        else if(potionUIObject.activeSelf)
        {
            potionUIObject.SetActive(false);
        }
    }
}
