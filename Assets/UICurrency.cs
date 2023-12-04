using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICurrency : MonoBehaviour
{
    [SerializeField] TMP_Text currencyText;
    private Animator coinAnim;

    private void Start()
    {
        coinAnim = GetComponentInParent<Animator>();
    }

    public void SetCurrency(int currency){
        coinAnim.SetTrigger("TransIn");
        currencyText.text = ""+currency;
    }
}
