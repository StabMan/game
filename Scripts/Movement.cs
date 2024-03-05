using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float speed;
    public float jumpForse;
    private float moveInput;


    private Rigidbody2D rb;

    private bool isGrounded = true;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;


    bool isFacingRight = true;
    private Animator anim;

    

    

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
      

    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            anim.SetBool("isRun", true);
        }
        else
        {
            anim.SetBool("isRun", false);
        }


        if (isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity = Vector2.up * jumpForse;
        }
        else if (Input.GetKeyDown(KeyCode.W) && isGrounded == true) ;
        }
        
    }
    private void FixedUpdate()
    {


        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        anim.SetBool("Ground", isGrounded);


        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (moveInput > 0 && !isFacingRight)
            flip();
        else if (moveInput < 0 && isFacingRight)
            flip();
    }
    void flip()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);

        if (isGrounded && Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("Ground", false);
            rb.AddForce(new Vector2(0, 1300));
        }
    }
}
