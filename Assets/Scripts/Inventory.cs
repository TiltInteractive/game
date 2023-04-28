using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update
    public int[] items = new int[] { 0, 1 };
    public int[] itemsCount = new int[] { 0, 0 };


    public void AddItem(int index)
    {
        itemsCount[index] += 1;
        Debug.Log("added");
    }
    public int QuantityItem(int index)
    {
        return itemsCount[index];
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
