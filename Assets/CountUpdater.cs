using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountUpdater : MonoBehaviour
{
    public int CoinCount;
    public int MaxCoinCount = 128;
    public int MedKitCount;
    public int MaxKitCount = 4;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("MedKit").GetComponent<TMP_Text>().text = "123";
    }
    void Update() 
    {
        
    }
}
