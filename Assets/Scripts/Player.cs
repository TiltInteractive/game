using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float speed;
    
    public static Vector2 direction;
    private Rigidbody2D rb;
    
    public Animator animator;

    // private BoxCollider2D boxCollider;
    // private Vector3 moveDelta;
    // private float WalkSpeed = 0f;
    // private float MaxSpeed = 2f;
    // private RaycastHit2D hit;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

      //  boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update() {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(direction.x) != 0 || Mathf.Abs(direction.y) != 0)
        {
            animator.SetFloat("move", 1);
        } else
        {
            animator.SetFloat("move", 0);
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed  * Time.fixedDeltaTime);


        // float x = Input.GetAxisRaw("Horizontal");
        // float y = Input.GetAxisRaw("Vertical");


        // Debug.Log(hit.collider);

        // // Reset moveDelta
        // moveDelta = new Vector3(x * WalkSpeed,y * WalkSpeed,0);

        // // Swap sp direct
        if (direction.x < 0) {
            transform.localScale = Vector3.one;
        }
        else if (direction.x > 0) {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // hit = Physics2D.BoxCast(transform.position,boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Creature", "Block"));
        
        // if (hit.collider == null)
        // {
        //     transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        // }


        // hit = Physics2D.BoxCast(transform.position,boxCollider.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Creature", "Block"));
        
        // if (hit.collider == null)
        // {
        //     transform.Translate(moveDelta.x * Time.deltaTime, 0 , 0);
        // }


        // // dvizhenie


        // if (x != 0 || y != 0)
        // {
        //     if (WalkSpeed < MaxSpeed) { WalkSpeed = WalkSpeed + 0.2f * MaxSpeed; }

        // } else
        // {
        //     if (WalkSpeed > 0f) { WalkSpeed = 0; }
                
        // }
    }

}
