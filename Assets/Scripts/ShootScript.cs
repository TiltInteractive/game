using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Gun;
    Vector2 direction;
    private Vector2 parentdir;

    public SpriteRenderer spi;

    public GameObject Bullet;

    public float BulletSpeed;

    public Transform Shootpoint;
    void Start()

    {
        Gun = this.gameObject.transform.parent;
        Gun.transform.localScale = new Vector3(-1, 1, 1);
        Shootpoint = this.gameObject.transform.GetChild(0);

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       
        FaceMouse();
        direction = mousePos - (Vector2)Gun.position;
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject BulletIns = Instantiate(Bullet, Shootpoint.position,Shootpoint.rotation);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(BulletIns.transform.right * BulletSpeed);
    }

    void RotationUpdate(){

        if (Player.direction.x < 0) {

            Gun.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (Player.direction.x > 0) {

            Gun.transform.localScale = Vector3.one;
            
        }


        if(direction.x < 0){
            spi.flipY = true;
        } else {
            spi.flipY = false;
        }
    }

    void FaceMouse()
    {
        Gun.transform.right = direction;
        RotationUpdate();

    }
}
