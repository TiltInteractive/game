using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public Vector2 new_position;
    public Scene newScene;
    public RoomGeneration Rmg;
    public bool Shop;
    public void Start()
    {
        Shop = GameObject.Find("room").GetComponent<RoomGeneration>().shop;
        new_position = new Vector2(0, -0.65f);
        Rmg = new RoomGeneration();
    }
    
    void RoomDestroy (Collider2D other)
    {
        other.transform.position = new_position;
        Debug.Log("1");

        gameObjects = GameObject.FindGameObjectsWithTag("roomComponent");

        foreach (var go in gameObjects)
        {
            Destroy(go);
        }

        RoomGeneration.level += 1;
        clone_room();
        Debug.Log(RoomGeneration.level);
        Debug.Log(RoomGeneration.part);
        GameObject.Find("room").GetComponent<RoomGeneration>().shop = Shop;
    }

    GameObject[] gameObjects;
    void OnTriggerEnter2D(Collider2D other) { 
        if (other.gameObject.tag != "Player")
        {
            return;
        }

        if (Shop)
        {
            SceneManager.LoadScene("shop_area");
            Shop = false;
        }
        Shop = true;
        RoomDestroy(other);


    }

    void clone_room(){
        
        Rmg.Start();
    }

}
