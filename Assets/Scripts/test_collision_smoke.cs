using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class test_collision_smoke : MonoBehaviour
{

    public int damage = 5;
    public string enemyTag = "Enemy";



    void OnParticleCollision(GameObject target)
    {
        // Collider2D coll = target.GetComponent<Collider2D>();
        if (target.tag == "Enemy")
        {
            Health health = target.GetComponent<Health>();
            health.takeDamage(damage);
        }

    }

    private void OnParticleTrigger()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();
        Component component = ps.trigger.GetCollider(0);
        Health health = component.GetComponent<Health>();
        health.takeDamage(damage);
    }

}