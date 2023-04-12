using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public int collisionDamage = 10;
    public string collisionTag;

    public float health;
    public PlayerHealth playerhealth;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
        private void OnCollisionEnter2D(Collision2D coll)
        {
            if (coll.gameObject.tag == collisionTag)
            {

                if (collisionTag == "Player"){
                    
                }
                playerhealth health = coll.gameObject.GetComponent<PlayerHealth>();
                health.takeDamage(collisionDamage);
            }
        }
}
