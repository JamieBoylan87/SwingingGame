 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementForce;
    public float jumpForce;
    [Space(5)]
    [Range(0, 100f)] public float raycastDistance = 1.5f;
    private Rigidbody2D rb;
    public LayerMask whatIsGround;

    public Animator anim;
    public Transform head;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Movement();
        Jump();
    }

    private void Movement()
    {
        if (IsGrounded())
        {
            float xDir = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(xDir * (movementForce * Time.deltaTime), rb.velocity.y);
            if (xDir != 0)
            {
                head.localScale = new Vector3(xDir, 1f, 1f);
            }
            if (xDir > 0)
            {
                anim.SetBool("Walk", true);
                anim.SetBool("WalkLeft", false);
            }
            if (xDir < 0)
            {
                anim.SetBool("Walk", false);
                anim.SetBool("WalkLeft", true);
            }
            if (xDir == 0)
            {
                anim.SetBool("Walk", false);
                anim.SetBool("WalkLeft", false);
            }
        }
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            if (IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.deltaTime);
            }
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, whatIsGround);
        return hit.collider != null;
    }
}
