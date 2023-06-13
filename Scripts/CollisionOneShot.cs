using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionOneShot : MonoBehaviour

{
    public int collisionDamage = 100;
    public string collisionTag;
    // Start is called before the first frame update

    void damage(Collider2D coll){
        if (coll.gameObject.tag == collisionTag)
        {
            Debug.Log("coll");
            PlayerHealth health = coll.gameObject.GetComponent<PlayerHealth>();

            health.takeDamage(collisionDamage);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D coll)
    {

        damage(coll);

    }
}
