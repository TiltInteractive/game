using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Start is called before the first frame update
    public int index = 0;
    void Start()
    {
        
    }
    void OnTriggerEnter2D(Collider2D obj) //«Наезд» на объект
    {
        if (obj.transform.tag == "Player")
        {
            obj.GetComponent<Inventory>().AddItem(index);//Если наехал игрок, то он сможет подобрать предмет
            Destroy(gameObject); //Удаление объекта с карты
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
