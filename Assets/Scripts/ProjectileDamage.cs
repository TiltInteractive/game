using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    // Start is called before the first frame update

    public int damage = 10;
    public string enemyTag;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D coll)
        {
            if (coll.gameObject.tag == enemyTag)
            {
                Health health = coll.gameObject.GetComponent<Health>();
                health.takeDamage(damage);
                
            }
            Destroy(gameObject);
        }
}
