using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heal : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H))
        {
            if (player.transform.GetComponent<Inventory>().QuantityItem(0) > 0)
            {
                player.transform.GetComponent<PlayerHealth>().SetHealth(50);
                player.transform.GetComponent<Inventory>().removeItem(0, 1);
            }
        }
    }
}
