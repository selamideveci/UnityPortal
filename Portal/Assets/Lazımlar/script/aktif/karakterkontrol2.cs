using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class karakterkontrol2 : MonoBehaviour
{
    public float jumpforce = 2.0f;
    public float jumpDoubleForce = 2.0f;
    public float speed = 1.0f;
    public float moveDirection;

    private bool jump;
    private bool grounded = true;
    private bool moving;
    private bool canDouble;

    private Rigidbody2D rigi2d;
    private Animator anim;
    private SpriteRenderer _spriteRenderer;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Start()
    {

        rigi2d = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void FixedUpdate()
    {
        if (rigi2d.velocity != Vector2.zero)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        rigi2d.velocity = new Vector2(speed * moveDirection, rigi2d.velocity.y);

        if (jump == true) //
        {
            if (canDouble == true)
            {
                rigi2d.velocity = new Vector2(rigi2d.velocity.x, jumpforce); //
            }
            else
            {
                rigi2d.velocity = new Vector2(rigi2d.velocity.x, jumpDoubleForce);
            }
            jump = false; //
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = -1.0f;
                _spriteRenderer.flipX = true;
                anim.SetFloat("speed", speed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = 1.0f;
                _spriteRenderer.flipX = false;
                anim.SetFloat("speed", speed);
            }
        }
        else if (grounded == true)
        {
            moveDirection = 0.0f;
            anim.SetFloat("speed", 0.0f);
        }

        if (grounded == true && Input.GetKeyDown(KeyCode.W))
        {

            jump = true;
            if (canDouble)
            {
                grounded = false;
                canDouble = false;
            }
            else
            {
                canDouble = true;
            }
            anim.SetTrigger("jump");
            anim.SetBool("grounded", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("zemin"))
        {
            anim.SetBool("grounded", true);
            grounded = true;
        }
    }

    
}
