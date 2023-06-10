using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void FadeToLevel()
    {
        anim.SetTrigger("Fade");
    }

    public void OnFadeComplete()
    {
        GameObject.Find("level_end");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
