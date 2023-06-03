using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogManager : MonoBehaviour
{
    public GameObject Dialog;
    public GameObject shopMenu;
    public TMP_Text Text;
    public string[] message;
    public bool dialogStat = false;
    // Start is called before the first frame update
    void Start()
    {
        message = new string[10];
        message[0] = "Аптечка";
        message[1] = "asdt";
        Dialog.SetActive(false);
        Debug.Log("Asdasd");
        GameObject temp = GameObject.Find("Player");
        Player ot = temp.GetComponent<Player>();
        ot.enabled = false;

        PlayerH other = temp.GetComponent<PlayerH>();
        other.enabled = true;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Dialog.SetActive(true);

            dialogStat = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Dialog.SetActive(false);
            dialogStat = false;
            shopMenu.SetActive(false);
    
        }
    }

    void movementToggle(bool f)
    {
        GameObject temp = GameObject.Find("Player");
        PlayerH other = temp.GetComponent<PlayerH>();
        if (f)
        {
            other.enabled = true;
        }
        else
        {
            other.enabled = false;
        }
    }
    // Update is called once per frame
    public void DialogStart ()
    {
        Dialog.SetActive(false);
        shopMenu.SetActive(dialogStat);
        movementToggle(false);
    }
    public void DialogExit()
    {
        Dialog.SetActive(true);
        shopMenu.SetActive(false);
        movementToggle(true);
    }
    void Update()
    {
        if (dialogStat)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                DialogStart();
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                DialogExit();
            }

        }
    }
}
