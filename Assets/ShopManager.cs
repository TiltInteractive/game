using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject Manager = GameObject.Find("Manager");
        TMP_Text[] Goods = Manager.GetComponentsInChildren<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter(Collision2D coll)
    {
        Debug.Log("ooopa");
    }

}
