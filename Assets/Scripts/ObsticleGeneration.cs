using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ObsticleGeneration : MonoBehaviour
{
    public Sprite box;
    public Sprite[] spriteArray;
    public RoomGeneration Roomg = new RoomGeneration();

    void Start()
    {
        /*spriteArray = Resources.LoadAll<Sprite>("Textures/room/room_sheet");
        box = spriteArray[1];*/

        Generation(box);
    }

    void Generation (Sprite boxx)
    {
        Vector2 pos = new Vector2(2, 2);

        Roomg.create(boxx, pos, "*");
        UnityEngine.Debug.Log("11");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
