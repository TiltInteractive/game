using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float health;
    public float maxHealth = 100;
    public bool isInvincible = false;
    public float invincibilityDurationSeconds = 1.5f;
    private IEnumerator BecomeTemporarilyInvincible()
        {
            Debug.Log("Player turned invincible!");
            isInvincible = true;

            yield return new WaitForSeconds(invincibilityDurationSeconds);

            isInvincible = false;
            Debug.Log("Player is no longer invincible!");
        }
    public void takeDamage(int damage) {
        Debug.Log("taken");
        if (isInvincible) return;

        health -= damage;
        
        
        if (health <= 0)

        {
            var anim = GetComponent<Animator>();
            anim.Play("Player_death");

            // Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        }
        StartCoroutine(BecomeTemporarilyInvincible());
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
