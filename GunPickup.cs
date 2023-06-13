using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickup : MonoBehaviour
{
    private int index;
    private GameObject gun;
    private GunInit gunInit;

    void OnTriggerEnter2D(Collider2D obj) //«Наезд» на объект
    {
        

        if (obj.transform.tag == "Player")
        {
            switch (gameObject.transform.name)
            {
                case "smoke_gun":
                    index = 1;
                    break;
                case "Handgun":
                    index = 0;
                    break;
            }
            Debug.Log(index);
            gunInit = GameObject.Find("Gun").GetComponent<GunInit>();
            gunInit.AddGun(index);

            Destroy(gameObject); //Удаление объекта с карты
        }
    }

}
