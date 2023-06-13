using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CollisionDamage : MonoBehaviour
{
    // Start is called before the first frame update
    public int collisionDamage = 10;
    public string collisionTag;
    public float itime = 10;
    public int damagee = 5;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator damage(Collider2D coll)
    {
        if (coll.gameObject.tag == collisionTag)
        {
            Debug.Log("coll");
            PlayerHealth health = coll.gameObject.GetComponent<PlayerHealth>();

            health.takeDamage(collisionDamage);
            yield return new WaitForSeconds(0.1f);
        }
    }
    private void OnTriggerEnter2D(Collider2D coll)
    {

        StartCoroutine(damage(coll));

    }

    void OnCollisionExit2D(Collision2D enemy)
    {
        StopAllCoroutines();
    }


}
