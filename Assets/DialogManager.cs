using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DialogManager : MonoBehaviour
{
    public GameObject Dialog;
    public TMP_Text Text;
    public string[] message;
    public bool dialogStat = false;
    // Start is called before the first frame update
    void Start()
    {
        message = new string[10];
        message[0] = "asd";
        message[1] = "asdt";
        Dialog.SetActive(false);
        Debug.Log("Asdasd");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Dialog.SetActive(true);
            Text.text = message[0];
            dialogStat = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Dialog.SetActive(false);
            dialogStat = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
