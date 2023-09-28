using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class TransparencyAnim : MonoBehaviour
{
    public TMP_Text text;

    [SerializeField] float transparency;
    private string transparencyString;

    [SerializeField] int transparencyRounded;
    [SerializeField] float fadeRate;

    // Start is called before the first frame update
    void Start()
    {
        transparencyString = "bb" ;
        transparency = 99;
        
        textUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        if (transparency > 0)
        {
            transparency -= fadeRate * Time.deltaTime;
            transparencyRounded = (int)Mathf.Round(transparency);
            transparencyString = transparencyRounded.ToString();
        }
        else
        {
            transparency = 0;
        }
        textUpdate();
    }

    void textUpdate()
    {
        if (transparencyRounded >= 10)
        {
            text.text = $"<color=#ffffff{transparencyString}>Placeholder\nTitle";          
        }
        else
        {
            text.text = $"<color=#ffffff0{transparencyString}>Placeholder\nTitle";
        }       
    }
}
