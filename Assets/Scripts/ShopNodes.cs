using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopNodes : MonoBehaviour
{
    [SerializeField] bool revealed;
    [SerializeField] ArrayList items = new ArrayList();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        revealed = false;
        
    }

    private bool isRevealed()
    {
        return true;
        //if player is close, it is revealed. If the player is not, then it is not revealed
    }
}
