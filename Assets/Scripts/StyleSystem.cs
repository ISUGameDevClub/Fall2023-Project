using UnityEngine;

public class StyleSystem : MonoBehaviour
{
    //gian sucks-c
    private PlayerMovement playerMovement;
    private PlayerHealth playerHealth;
    private PlayerAttack playerCombat;

    [System.NonSerialized] public string currentStyleName;
    public Style[] styles; //An array of styles.
    private int currentStyleIndex; //The current style index.

    //Weapon Inventory
    public static bool hasRailgun = false;

    //UI Styling
    public GameObject cannonText;
    public GameObject railgunText;

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
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(currentStyleIndex == 0) //Allow change to Railgun
            {
                if(hasRailgun)
                {
                    currentStyleIndex += 1;
                    ChangeStyle(currentStyleIndex);
                }
            }
            else // Change to simple cannon
            {
                currentStyleIndex -= 1;
                ChangeStyle(currentStyleIndex);
            }
        }
    }

    public void ChangeStyle(int index)
    {
        currentStyleName = styles[index].styleName;
        playerMovement.SetSpeed(styles[index].moveSpeed);
        playerHealth.SetDamageTakenMultiplier(styles[index].damageTakenMultiplier);
        playerCombat.setPrimaryWeapon(styles[index].primaryWeapon);
        if(index == 0)
        {
            cannonText.GetComponent<Animator>().SetTrigger("CannonText");
        }
        else if(index == 1)
        {
            railgunText.GetComponent<Animator>().SetTrigger("RailgunText");
        }
    }

    //Struct for holding styles.
    [System.Serializable]
    public struct Style
    {
        public string styleName;
        public int primaryWeapon;
        public float moveSpeed;
        public float damageTakenMultiplier;
    }
}
