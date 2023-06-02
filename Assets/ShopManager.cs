using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject plr; 
    void Start()
    {
        plr = GameObject.Find("Player");
        GameObject Manager = GameObject.Find("Manager");
        TMP_Text[] Goods = Manager.GetComponentsInChildren<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Sell(int id, int price)
    {
        int money = plr.GetComponent<Inventory>().QuantityItem(2);
        if (money - price >= 0)
        {
            plr.GetComponent<Inventory>().removeItem(2, money);
            plr.GetComponent<Inventory>().AddItem(id);
        } 
    }

    public void Med()
    {
        Sell(0, 16);
        Debug.Log("Med sell");
        Debug.Log(plr.GetComponent<Inventory>().QuantityItem(2));
    }
    public void Grenade()
    {
        Sell(1, 32);
    }
}
