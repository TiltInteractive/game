using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Image healthBar;
    public float health;
    public float maxHealth;

    public PlayerHealth playerhealth;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health = playerhealth.health;
        maxHealth = playerhealth.maxHealth;
        healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1 );

    }
}
