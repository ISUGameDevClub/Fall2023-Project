using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class currencyManagement : MonoBehaviour
{
    int goldAmount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    int getGoldAmount(){
        return goldAmount;
    }
    void addGold(int amount){
        goldAmount = goldAmount + amount;
    }

}
