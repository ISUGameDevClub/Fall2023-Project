using UnityEngine;

//ne
//Grab an executive once you finish this script up - C
public class currencyCount : MonoBehaviour
{
    public int count;
    GameObject uiCurrency;

    // Start is called before the first frame update
    void Start()
    {
        uiCurrency = GameObject.Find("Currency");
        uiCurrency.GetComponent<UICurrency>().SetCurrency(count);
        /*
        //grabs amount from playerPrefs
        count = PlayerPrefs.GetInt("amount");
        */
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //temp test
        //every click adds 1 to count
        if(Input.GetButtonDown("Fire1"))
        {
            addAmount(1);
            //Debug
            Debug.Log("Currency: " + getAmount());
        }
        if(Input.GetButtonDown("Jump"))
        //every spacebar removes 10 from count
        {
            removeAmount(10);
            //Debug
            Debug.Log("Currency: " + getAmount());
        }
        */
        
    }

    //get
    public int getAmount(){
        //gets count from PlayerPrefs amount
        count = PlayerPrefs.GetInt("amount");
        return count;
    }

    //set
    public void setAmount(int newCount){
        //sets newCount to PlayerPrefs amount
        PlayerPrefs.SetInt("amount", newCount);
        uiCurrency.GetComponent<UICurrency>().SetCurrency(count);
    }

    //add
    public void addAmount(int addCount){
        //add addCount to PlayerPrefs amount
        count = getAmount() + addCount;
        //sets new Amount in PlayerPrefs
        setAmount(count);
    }

    //remove
    public void removeAmount(int removeCount){
        //if current Amount is more than removeCount
        if(getAmount() >= removeCount)
        {
            //subtract removeCount from PlayerPrefs amount
            count = getAmount() - removeCount;
            //sets new Amount in PlayerPrefs
            setAmount(count);
        }
    }

    //under amount
    public bool underAmount(int removeCount){
        //check that amount is more than removeCount
        if(getAmount() >= removeCount)
        {
            //if enough currency
            return true;
        }
        else
        {
            //if not enough currency
            return false;
        }
    }
}
