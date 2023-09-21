using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondaryAttack : MonoBehaviour
{
    public GameObject placeholder;
    
    
    void Update()
    {
        CheckForClick();
    }

    void CheckForClick()
    {
       if(Input.GetKeyDown(KeyCode.Mouse1))
       {
            Instantiate(placeholder,transform);
       }
    }
}
