using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_collision_smoke : MonoBehaviour
{
    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;

    public int damage = 10;
    public string enemyTag;

    void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

        Rigidbody rb = other.GetComponent<Rigidbody>();
        int i = 0;

        while (i < numCollisionEvents)
        {
            if (rb)
            {
                void OnCollisionEnter2D(Collision2D coll)
                {
                    if (coll.gameObject.tag == enemyTag)
                    {
                        Health health = coll.gameObject.GetComponent<Health>();
                        health.takeDamage(damage);

                    }
                    Destroy(gameObject);
                }
            }
            i++;
        }
    }
}
