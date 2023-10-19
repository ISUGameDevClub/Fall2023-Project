using UnityEngine;

public class currencyManagement : MonoBehaviour
{
    //is this related to currency count or is this extra? tell an exec - C
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
