using UnityEngine;

//ne
//Grab an executive once you finish this script up - C
public class CurrencyCount : MonoBehaviour
{
    public static int currentCurrency;
    private UICurrency uiCurrency;

    // Start is called before the first frame update
    void Start()
    {
        uiCurrency = FindObjectOfType<UICurrency>();
        uiCurrency.SetCurrency(currentCurrency);
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetKey(KeyCode.Slash))
        {
            AddAmount(100);
        }
    }

    //get
    public int GetAmount(){
        return currentCurrency;
    }

    //add
    public void AddAmount(int addCount){
        currentCurrency += addCount;
        uiCurrency.SetCurrency(currentCurrency);
    }

    //remove
    public void RemoveAmount(int removeCount){
        uiCurrency.SetCurrency(currentCurrency);
        currentCurrency -= removeCount;
    }
}
