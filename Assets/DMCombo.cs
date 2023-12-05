using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DMCombo : MonoBehaviour
{
    private int currentCombo;
    public TMP_Text comboMeter;
    public TMP_Text comment;

    private float currentTimer;
    private Animator comboAnim;
    private bool resettingAnim = false;
    private bool comboActive = false;
    public float maxTimer = 5f;

    // Start is called before the first frame update
    void Start()
    {
        currentCombo = 0;
        comboActive = false;
        comboAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(comboActive)
        {
            comboAnim.SetBool("ComboActive", true);
        }

        if(currentTimer >= 0)
        {
            currentTimer -= Time.deltaTime;
        }
        else if(comboActive)
        {
            ResetCombo();
        }
    }

    public void AddToCombo()
    {
        if(!resettingAnim)
        {
            currentCombo++;
            currentTimer = maxTimer;
            UpdateUI();

            if (currentCombo >= 3)
            {
                comboActive = true;
            }
        }
    }

    private void UpdateUI()
    {
        comboMeter.text = "x " + currentCombo;

        if (currentCombo <= 4)
        {
            comment.text = "";
        }
        if (currentCombo <= 5)
        {
            comment.text = "Okay!";
        }
        else if(currentCombo <= 15)
        {
            comment.text = "Wow!";
        }
        else if(currentCombo <= 25)
        {
            comment.text = "GOB-SMACKING!!";
            comboAnim.SetTrigger("Shake");
        }
        else if(currentCombo <= 35)
        {
            comment.text = "CRAZY!!";
        }
        else if(currentCombo <= 45)
        {
            comment.text = "UNSTOPPABLE!!!";
        }
        else if(currentCombo <= 55)
        {
            comment.text = "STYLISH!!!";
        }
    }

    private void ResetCombo()
    {
        resettingAnim = true;
        comboActive = false;
        comboAnim.SetBool("ComboActive", false);
        currentCombo = 0;
    }

    public void DoneResetting()
    {
        resettingAnim = false;
    }
}
