using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{
    public Vector2 new_position;
    public Scene newScene;
    public RoomGeneration Rmg;
    public void Start()
    {
        new_position = new Vector2(0, -0.65f);
        Rmg = new RoomGeneration();
    }
    

    GameObject[] gameObjects;
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
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
        }
        
    }

    void clone_room(){
        
        Rmg.Start();
    }

}
