using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;
    private bool onPlatform;
    public bool isFlipped;
    float horizInput;
    [SerializeField] private float speed;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        rb.gravityScale = 1;
    }

    
    void Update()
    {
        
        float horizInput = Input.GetAxis("Horizontal");
        animator.SetBool("isWalking", horizInput != 0);
        animator.SetBool("isGrounded", isGrounded);
    }

    private void FixedUpdate()
    {
        Move();
        Flip();
    }

    private void Move()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            
            rb.velocity = new Vector2(rb.velocity.x, speed);
            isGrounded = false;
        }
    }

    private void Flip()
    {
        float horizInput = Input.GetAxis("Horizontal");

        if (horizInput > 0.01f)
        {
            isFlipped = false;
            if(onPlatform) 
            {
                //correct the scale of the player when on platform
                transform.localScale = new Vector3((float)-0.796019912, (float)10.3225813, 4);
            }
            else
            {
                transform.localScale = new Vector3(-4, 4, 4);
            }
        }
        else if (horizInput < -0.01f)
        {
            isFlipped = true;
            if (onPlatform)
            {
                //correct the scale of the player when on platform
                transform.localScale = new Vector3((float)0.796019912, (float)10.3225813, 4);
            } else
            {
                transform.localScale = new Vector3(4, 4, 4);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded=true;
        }

        //child the player to the platform
        if(collision.gameObject.tag == "Platform")
        {
            isGrounded=true;
            onPlatform = true;
            this.transform.SetParent(collision.transform, true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //unchild the player from the platform
        if (collision.gameObject.tag == "Platform")
        {
            onPlatform = false;
            this.transform.SetParent(null);
        }
           
    }

}
