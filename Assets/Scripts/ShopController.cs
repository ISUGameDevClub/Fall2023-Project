using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    public bool shopActive;

    [SerializeField] BoxCollider2D shopTrigger;
    [SerializeField] GameObject ShopVisible;

    // Start is called before the first frame update
    void Start()
    {
        shopActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (shopActive == true)
        {
            ShopVisible.SetActive(true);
        }
        else
        {
            ShopVisible.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (shopActive == false && collision.gameObject.tag == "Player")
        {
            shopActive = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (shopActive == true && collision.gameObject.tag == "Player")
        {
            shopActive = false;
        }
    }
}
