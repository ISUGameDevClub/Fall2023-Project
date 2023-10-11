using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Nicholas Eitenmiller

public class currencyCount : MonoBehaviour
{
    public int count;

    // Start is called before the first frame update
    void Start()
    {
        /*
        //grabs amount from playerPrefs
        count = PlayerPrefs.GetInt("amount");
        */
    }

    // Update is called once per frame
    void Update()
    {

        //temp test
        //every click adds 1 to count
        if(Input.GetButtonDown("Fire1"))
        {
            addAmount(1);
            //Debug
            Debug.Log("Currency: " + getAmount());
        }
    }

    //get
    int getAmount(){
        //gets count from PlayerPrefs amount
        count = PlayerPrefs.GetInt("amount");
        return count;
    }

    //set
    void setAmount(int newCount){
        //sets newCount to PlayerPrefs amount
        PlayerPrefs.SetInt("amount", newCount);
    }

    //add
    void addAmount(int addCount){
        //add addCount to PlayerPrefs amount
        count = getAmount() + addCount;
        //sets new Amount in PlayerPrefs
        setAmount(count);
    }

    //remove
    void removeAmount(int removeCount){
        //if current Amount is more than removeCount
        if(getAmount() >= removeCount);
        {
            //subtract removeCount from PlayerPrefs amount
            count = getAmount() - removeCount;
            //sets new Amount in PlayerPrefs
            setAmount(count);
        }
    }

}
