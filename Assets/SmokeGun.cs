using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeGun : MonoBehaviour
{
    public ParticleSystem spray;
    // Start is called before the first frame update
    void Start()
    {
        spray = GetComponent<ParticleSystem>();
        spray.Stop();
        spray.enableEmission = false;

    }

    void Reload()
    {
        var main = spray.main;
        main.duration = 1.5f;
        Debug.Log("reload");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Z");
            spray.Play();
            spray.enableEmission = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            spray.Stop();
            spray.enableEmission = false;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

}
