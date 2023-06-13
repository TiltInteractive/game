using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public bool smooth = false;
    public float Speed;
    public GameObject Player;

    void FixedUpdate()
    {
        if (smooth) {
            Vector3 target = new Vector3()
            {
                x = Player.transform.position.x,
                y = Player.transform.position.y,
                z = Player.transform.position.z - 10,
            };
            transform.position = Vector3.Lerp(transform.position, target, Speed * Time.fixedDeltaTime);
        }
    }


    public Transform lookAt;
    public float boundX = 0.15f;
    public float boundY =  0.05f;

    private void LateUpdate()
    {
        if(!smooth) {
            Vector3 delta = Vector3.zero;
            // X axis
            float deltaX = lookAt.position.x - transform.position.x;
            if(deltaX > boundX || deltaX < -boundX)
            {
                if(transform.position.x < lookAt.position.x)
                {
                    delta.x = deltaX - boundX;

                } else {
                    delta.x = deltaX + boundX;
                }
            }
            // Y axis
            float deltaY = lookAt.position.y - transform.position.y;
            if(deltaY > boundY || deltaY < -boundY) {
                if(transform.position.y < lookAt.position.y)
                {
                    delta.y = deltaY - boundY;

                }
                else {
                    delta.y = deltaY + boundY;
                }
            }


            transform.position += new Vector3(delta.x, delta.y, 0);
            
    }
    }
}

