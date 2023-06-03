using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEditor.Animations;

public class LevelEnd : MonoBehaviour
{
    public Vector2 new_position;
    public Scene newScene;
    public RoomGeneration Rmg;
    public bool Shop;
    private GameObject[] enemies;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int i = 0;
            enemies = GameObject.FindGameObjectsWithTag("Enemy");

            i = enemies.Length;
            if (i == 0)
            {
                Debug.Log("freee");
                BoxCollider2D[] Cols;
                Cols = GetComponents<BoxCollider2D>();
                Cols[1].enabled = false;
            }
            else
            {
                Debug.Log("sosi");
            }
        }
        
    }

    void clone_room(){
        
        Rmg.Start();
    }

}
