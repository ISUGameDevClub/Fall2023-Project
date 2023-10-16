using UnityEngine;

public class StyleSystem : MonoBehaviour
{
    //gian sucks-c
    private PlayerMovement playerMovement;
    [System.NonSerialized] public string currentStyle;
    public Style[] styles; //An array of styles.

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        ChangeStyle(0); //Default style.
    }

    private void Update()
    {
        //Changes style by index.
        //0 is first style, 1 is second style, etc...
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeStyle(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeStyle(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ChangeStyle(2);
        }
    }

    public void ChangeStyle(int index)
    {
        currentStyle = styles[index].styleName;
        playerMovement.SetSpeed(styles[index].moveSpeed);
        //Add UI element to represent changed styleName.
        //playerHealth.damageMultiplier = styles[index].damageMultiplier;
        //playerMovement.moveTech = styles[index].moveTech;
        //playerCombat.currentPrimary = styles[index].primaryWeapon;
        //playerCombat.currentSuper = styles[index].superAttack;

        Debug.Log("Current Style: " + currentStyle);
    }

    //Struct for holding styles.
    [System.Serializable]
    public struct Style
    {
        public string styleName;
        public float moveSpeed;
        public float damageMultiplier;
        public GameObject moveTech;
        public GameObject superAttack;
        public GameObject primaryWeapon;
    }
}
