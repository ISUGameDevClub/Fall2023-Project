using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    
    private float currentHealth = 100;
    public float maxHealth = 25f;

    [SerializeField] float knockedTime;
    Rigidbody2D rb;
    [SerializeField] float knockbackForce;
    GameObject SFXController;
    public delegate void PlayerDeathEventHandler();
    public static event PlayerDeathEventHandler OnPlayerDeath;

    //iFrames
    private float currInvincibleTimer;
    public float invincibleTimer = 2.5f;
    private bool invincible = false;

    //Style System Stats
    private float damageTakenMultiplier = 1f; //Usage: damage * damageTakenMultiplier

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        SFXController = GameObject.Find("SoundFXManager");
        currentHealth = maxHealth;
    }

    public void Update()
    {
        if(invincible)
        {
            if(currInvincibleTimer <= 0)
            {
                invincible = false;
            }
            else
            {
                currInvincibleTimer -= Time.deltaTime;
            }
        }
    }

    public void DamagePlayer(float damagePoint, Vector3 damageDirection) {
        if(!invincible)
        {
            invincible = true;
            currInvincibleTimer = invincibleTimer;

            //Knockback
            if (damageDirection != Vector3.zero && !GetComponent<PlayerMovement>().GetKnocked())
            {
                GetComponent<PlayerMovement>().SetKnocked(true);
                Vector3 knockDirection = transform.position - damageDirection;
                if (knockDirection.x >= 0)
                {
                    knockDirection = new Vector3(1, 1);
                }
                else
                {
                    knockDirection = new Vector3(-1, 1);
                }
                rb.AddForce(knockDirection.normalized * knockbackForce, ForceMode2D.Impulse);
                StartCoroutine(ResetKnocked());
            }

            SFXController.GetComponent<SFXController>().playSound(2);

            currentHealth -= (damagePoint * damageTakenMultiplier);
            if (currentHealth <= 0)
            {
                // Kill player Function Here
                OnPlayerDeath();
            }
        }
    }

    IEnumerator ResetKnocked(){
        yield return new WaitForSeconds(knockedTime);
        GetComponent<PlayerMovement>().SetKnocked(false);
    }

    public void HealPlayer(int healPoint) {
        currentHealth += healPoint;
        if (currentHealth > maxHealth){
            currentHealth = maxHealth;
        }
    }

    public void SetPlayerHealth(int newHealth) {
        currentHealth = newHealth;
    }

    //Style System Mechanics
    public void SetDamageTakenMultiplier(float newDamageMultiplier)
    {
        damageTakenMultiplier = newDamageMultiplier;
    }

    public float getCurrentHealth()
    {
        return currentHealth;
    }
}
