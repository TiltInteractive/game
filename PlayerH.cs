using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public class PlayerH : MonoBehaviour
{
    public float speed;
    public GameObject Gun;

    public static Vector2 direction;
    private Rigidbody2D rb;

    public Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gameObject.transform.position = new Vector2(0, -0.65f);
        Gun = GameObject.Find("Gun");
    }

    private void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = 0;

        if (Mathf.Abs(direction.x) != 0 || Mathf.Abs(direction.y) != 0)
        {
            animator.SetFloat("move", 1);
        }
        else
        {
            animator.SetFloat("move", 0);
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);

        if (direction.x < 0)
        {
            Gun.transform.localScale = new Vector3(-1, 1, 1);
            transform.localScale = Vector3.one;
        }
        else if (direction.x > 0)
        {
            Gun.transform.localScale = new Vector3(1, 1, 1);
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

}
