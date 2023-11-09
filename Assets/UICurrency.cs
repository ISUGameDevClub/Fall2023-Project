using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICurrency : MonoBehaviour
{
    [SerializeField] TMP_Text currencyText;

    public void SetCurrency(int currency){
        currencyText.text = ""+currency;
    }
}
