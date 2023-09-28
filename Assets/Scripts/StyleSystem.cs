using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StyleSystem : MonoBehaviour
{
    private PlayerMovement playerMovement;
    public string currentStyle;
    public Style[] styles;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        ChangeStyle("TestDefault"); //Default style.
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeStyle("TestDefault");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeStyle("TestFast");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeStyle("TestSlow");
        }
    }

    public void ChangeStyle(string styleName)
    {
        //Searches by stylename.
        foreach (Style style in styles)
        {
            if (style.styleName == styleName)
            {
                currentStyle = style.styleName;

                playerMovement.moveSpeed = style.moveSpeed;
                //Add UI element to represent changed styleName.
                //playerMovement.moveTech = style.moveTech;
                //playerCombat.currentPrimary = style.primaryWeapon;
                //playerCombat.currentSuper = style.superAttack;
            }
        }

        Debug.Log("Current Style: " + currentStyle);
    }

    //Struct for holding styles.
    [System.Serializable]
    public struct Style
    {
        public string styleName;
        public float moveSpeed;
        public GameObject moveTech;
        public GameObject superAttack;
        public GameObject primaryWeapon;
    }
}
