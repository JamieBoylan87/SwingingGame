using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float walkSpeed;
    public bool mustPatrol;
    public bool mustTurn;

    public Rigidbody2D rb;
    public Transform GroundCheck;
    public LayerMask groundLayer;
    public Balance balance;
    public Balance balance1;
    public Balance balance2;
    public Balance balance3;
    public Balance balance4;
    public Balance balance5;
    public Balance balance6;
    public PlayerController player;
    public Arms arms;
    public Arms arms1;
    public Arms arms2;
    public Arms arms3;



    void Start()
    {
        mustPatrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }
    }
    private void FixedUpdate()
    {
       if (mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(GroundCheck.position, 0.0001f, groundLayer);
        }
    }
    void Patrol()
    {
        if(mustTurn)
        {
            Flip();
        }
        rb.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            balance.Death();
            balance1.Death();
            balance2.Death();
            balance3.Death();
            balance4.Death();
            balance5.Death();
            balance6.Death();
            player.Death();
            arms.Death();
            arms1.Death();
            arms2.Death();
            arms3.Death();

        }
    }
}
