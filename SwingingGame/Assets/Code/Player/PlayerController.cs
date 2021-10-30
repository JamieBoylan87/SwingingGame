 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement speed
    public float movementForce;
    //Jump height
    public float jumpForce;
    [Space(5)]
    //Distance to check for platform beneath player (Higher number means you can basically fly)
    [Range(0, 100f)] public float raycastDistance = 1.5f;
    private Rigidbody2D rb;
    public LayerMask whatIsGround;

    public Animator anim;
    public Transform head;

    //Door Opening
    public GameObject[] gameObjects;

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
        //If you are on the ground, move
        if (IsGrounded())
        {
            float xDir = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(xDir * (movementForce * Time.deltaTime), rb.velocity.y);
            //Animation code
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
        //Jump
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            if (IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce * Time.deltaTime);
            }
        }
    }

    public bool IsGrounded()
    {
        //If you are grounded return true
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, whatIsGround);
        return hit.collider != null;
    }

    //Code to destroy key and door pulled from spongy
    void DestroyKey()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("Key");
        for (var i = 0; i < gameObjects.Length; i++)
            Destroy(gameObjects[i]);
    }
    void OpenDoor()
    {
        gameObjects = GameObject.FindGameObjectsWithTag("Door");
        for (var i = 0; i < gameObjects.Length; i++)
            Destroy(gameObjects[i]);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Key")
        {
            DestroyKey();
            OpenDoor();
        }
    }
}
