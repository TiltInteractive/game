using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_collision_smoke : MonoBehaviour
{

    public int damage = 1;
    public string enemyTag = "Enemy";

    void Start()
    {

    }

    void OnParticleCollision(GameObject target)
    {
       // Collider2D coll = target.GetComponent<Collider2D>();
        if (target.tag == "Enemy") {
            Health health = target.GetComponent<Health>();
            health.takeDamage(damage);
        }
        
    }

}