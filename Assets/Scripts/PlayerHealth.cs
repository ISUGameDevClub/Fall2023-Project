using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    
    public int playerHealth;
    [SerializeField] float knockedTime;
    Rigidbody2D rb;
    [SerializeField] float knockbackForce;
    GameObject healthUI;
    GameObject SFXController;
    [SerializeField] private int playerMaxHealth = 100;
    public delegate void PlayerDeathEventHandler();
    public event PlayerDeathEventHandler OnPlayerDeath;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        SFXController = GameObject.Find("SoundFXManager");
        healthUI = GameObject.Find("Health");
        playerHealth = playerMaxHealth;
    }

    public void DamagePlayer(int damagePoint, Vector3 damageDirection) {
        if(damageDirection!=Vector3.zero&&!GetComponent<PlayerMovement>().GetKnocked()){
            GetComponent<PlayerMovement>().SetKnocked(true);
            Vector3 knockDirection = transform.position-damageDirection;
            /*if(knockDirection.y<0){
                knockDirection = new Vector3(knockDirection.x,0,0);
            }*/
            if(knockDirection.x>=0){
                knockDirection=new Vector3(1,1);
            }else{
                knockDirection=new Vector3(-1,1);
            }
            rb.AddForce(knockDirection.normalized*knockbackForce,ForceMode2D.Impulse);
            StartCoroutine(ResetKnocked());
        }

        SFXController.GetComponent<SFXController>().playSound(2);
        healthUI.GetComponent<UIHealth>().ReduceHealth();
        playerHealth -= damagePoint;
        if (playerHealth <= 0) {
            // Kill player Function Here
            OnPlayerDeath();
        }
    }
    IEnumerator ResetKnocked(){
        yield return new WaitForSeconds(knockedTime);
        GetComponent<PlayerMovement>().SetKnocked(false);
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
