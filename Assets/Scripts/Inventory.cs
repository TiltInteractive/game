using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Start is called before the first frame update

    /*
    0 - medkit
    1 - Grenade
    2 - money
     
     */
    public int[] items = new int[4] { 0, 1, 2, 3 };
    public int[] itemsCount = new int[4] { 0, 0, 0, 0 };


    public void AddItem(int index)
    {
        itemsCount[index] += 1;
        Debug.Log("added");
    }
    public void removeItem(int index, int count)
    {
        itemsCount[index] -= count;
        Debug.Log("removed");
    }
    public int QuantityItem(int index)
    {
        return itemsCount[index];
    }

    void Start()
    {
        itemsCount[0] = 1;
        itemsCount[2] = 16;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
