using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCount : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obj;
    public string Tag = "med";
    private int i = 0;
    void Start()
    {
        obj = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Tag == "med") {
            i = 0;
        }
        GetComponent<TMP_Text>().text = (obj.GetComponent<Inventory>().QuantityItem(i)).ToString();
    }
}
