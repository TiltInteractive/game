using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.PlayerSettings;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    public float health;
    public float maxHealth = 100;
    private bool f = true;
    public GameObject money;



    public void takeDamage(int damage) {
        
        health -= damage;
      
        if (health <= 0)
        {
            var anim = GetComponent<Animator>();
            anim.Play("death");
            
            Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
            
        }
    }

    public void SetHealth(int restore) {
        health += restore;
        if (health >= maxHealth)
        {
            health = maxHealth;
        }
    }
    void Start()
    {
        money = Resources.Load<GameObject>("Prefab/Pickups/money");
        health = maxHealth;

    }

    void Update()
    {
        if (health <= 0 && f)
        {
            Instantiate(money, transform.position, Quaternion.identity);
            f = false;
        }
    }

    // Update is called once per frame

}
