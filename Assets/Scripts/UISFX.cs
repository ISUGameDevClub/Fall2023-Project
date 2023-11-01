using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISFX : MonoBehaviour
{
    SFXController sfxController;

    // Start is called before the first frame update
    void Start()
    {
        sfxController = FindObjectOfType<SFXController>();
    }

    public void ButtonHover()
    {
        sfxController.playSound(2);
    }

    public void ButtonSelectSFX()
    {
        sfxController.playSound(3);
    }
}
