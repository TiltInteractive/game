using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    private LevelEnd lv;
    private GameObject player;
    public GameObject DeathMenu;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        lv = new LevelEnd();
        DeathMenu = GameObject.Find("Death");
    }
    public void Restart()
    {
        /*        RoomGeneration.level = 1;
                RoomGeneration.part = 1;
                lv.Start();
                lv.rdest();
                DeathMenu.SetActive(false);
                Destroy(player);
                */
        SceneManager.LoadScene("Main");

    }
    public void Show()
    {
        DeathMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
