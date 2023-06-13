using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject player = GameObject.Find("Player");
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "roomComponent" && player.transform.position.x < 0.32f)
        {
            transform.position = transform.position + new Vector3(0, 0.32f, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
