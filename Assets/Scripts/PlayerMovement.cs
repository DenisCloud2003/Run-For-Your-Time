    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 4f;

    [HideInInspector]
    public float xAxis;
    private float yAxis;

    [SerializeField]
    private float jumpForce = 200;
    private int groundMask;
    private bool isGrounded;
    private bool isJumpPressed;
    private Rigidbody2D rgbd;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        groundMask = 1 << LayerMask.NameToLayer("Ground");
    }

    void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumpPressed = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Check whether or not the player is on the ground
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.3f, groundMask);
        
        if (hit.collider != null)
        {
            isGrounded = true;
        }
        else isGrounded = false;

        //Check update movement based on input
        Vector2 vel = new Vector2(0, rgbd.velocity.y);

        if (xAxis < 0)
        {
            vel.x = -moveSpeed;
            anim.SetFloat("Speed", moveSpeed);
        }
        else if (xAxis > 0)
        {
            vel.x = moveSpeed;
            anim.SetFloat("Speed", moveSpeed);
        }
        else
        {
            vel.x = 0;
            anim.SetFloat("Speed", 0f);
        }


        if (isJumpPressed && isGrounded)
        {   
            rgbd.AddForce(new Vector2(0, jumpForce));
            isJumpPressed = false;
        }

        rgbd.velocity = vel;
        
        if (rgbd.velocity.y > 0.1)
        {
            anim.SetBool("isJumping", true);
        }
        else if(rgbd.velocity.y < -0.1)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }
    }
}
