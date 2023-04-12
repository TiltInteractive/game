using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    public static float health;
    public static float maxHealth = 100;

    public void takeDamage(int damage) {
        health -= damage;
        if (health <= 0)
        {
            
            Destroy(gameObject);
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
        health = maxHealth;
    }

    // Update is called once per frame

}
