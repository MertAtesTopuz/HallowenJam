using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCoroller : MonoBehaviour
{
    [SerializeField] private int jumpSpeed;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer render;

    [SerializeField] private int Speed;
    private bool faceRight = true;
    public float moveInput1;
    [SerializeField] private TrailRenderer tr;

    [SerializeField] private float dashingVelocity = 14f;
    [SerializeField] private float dashingTime = 0.5f;
    private Vector2 dashingDir;
    private bool isDashing;
    private bool canDash;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * Speed, rb.velocity.y);
        moveInput1 = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        if (faceRight == true && moveInput1 < 0)
        {
            Flip();
        }
        else if (faceRight == false && moveInput1 > 0)
        {
            Flip();
        }

        Jump();

        if (isGrounded == true)
        {
            animator.SetBool("isJumping", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)&& canDash)
        {
            isDashing = true;
            canDash = false;
            tr.emitting = true;
            dashingDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (dashingDir ==Vector2.zero)
            {
                dashingDir = new Vector2(transform.localScale.x, 0);
            }

            StartCoroutine(DashStop());
        }

        if (isDashing)
        {
            rb.velocity = dashingDir.normalized * dashingVelocity;
            return;
        }

        if (isGrounded)
        {
            canDash = true;
        }
    }

    void Flip()
    {
        faceRight = !faceRight;
        render.flipX = !faceRight;
    }


    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && isGrounded == true)
        {
            animator.SetBool("isJumping", true);
            rb.velocity = Vector2.up * jumpSpeed;
            
        }
    }

    IEnumerator DashStop()
    {
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        isDashing = false;
    }
}
