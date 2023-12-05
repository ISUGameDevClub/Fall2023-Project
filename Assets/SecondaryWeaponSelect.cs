using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SecondaryWeaponSelect : MonoBehaviour
{
    public Button megaShot;
    public TMP_Text megaShotText;
    public Button dagger;
    public TMP_Text daggerText;
    public Button grenadeLauncher;
    public TMP_Text grenadeLauncherText;

    private void Start()
    {
        if(PlayerAttack.hasMegaShot == false)
        {
            megaShot.interactable = false;
            megaShotText.text = "???";
        }
        if(PlayerAttack.hasDagger == false)
        {
            dagger.interactable = false;
            daggerText.text = "???";
        }
        if(PlayerAttack.hasGrenadeLauncher == false)
        {
            grenadeLauncher.interactable = false;
            grenadeLauncherText.text = "???";
        }
    }

    public void SelectMegaShot()
    {
        PlayerAttack.SecondaryWeapon = 1;
    }

    public void SelectDagger()
    {
        PlayerAttack.SecondaryWeapon = 2;
    }

    public void SelectGrenadeLauncher()
    {
        PlayerAttack.SecondaryWeapon = 3;
    }
}
