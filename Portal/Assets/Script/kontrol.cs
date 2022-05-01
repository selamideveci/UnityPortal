using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kontrol : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public float jumpForce;
    private float moveInput;
    private bool facingRight;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
