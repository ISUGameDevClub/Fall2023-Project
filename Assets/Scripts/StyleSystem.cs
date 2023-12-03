using UnityEngine;

public class StyleSystem : MonoBehaviour
{
    //gian sucks-c
    private PlayerMovement playerMovement;
    private PlayerHealth playerHealth;
    private PlayerAttack playerCombat;

    [System.NonSerialized] public string currentStyle;
    public Style[] styles; //An array of styles.

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerHealth = GetComponent<PlayerHealth>();
        playerCombat = GetComponent<PlayerAttack>();

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

        //Testing purposes.
        if(Input.GetKeyDown(KeyCode.Backslash))
        {
            playerCombat.setSecondaryWeapon(1);
        }
    }

    public void ChangeStyle(int index)
    {
        currentStyle = styles[index].styleName;
        playerMovement.SetSpeed(styles[index].moveSpeed);
        playerHealth.SetDamageTakenMultiplier(styles[index].damageTakenMultiplier);
        playerCombat.setPrimaryWeapon(styles[index].primaryWeapon);
        //Add UI element to represent changed styleName.
        //playerCombat.currentSuper = styles[index].superAttack;

        Debug.Log("Current Style: " + currentStyle);
    }

    //Struct for holding styles.
    [System.Serializable]
    public struct Style
    {
        public string styleName;
        public int primaryWeapon;
        public int superAttack;
        public float moveSpeed;
        public float damageTakenMultiplier;
    }
}
