using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float runSpeed;
    public float jumpForce = 5f;
    public int maxJumps = 2;
    private int jumpsRemaining;
    private Rigidbody2D myRigidbody;
    private Animator myAnim;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        jumpsRemaining = maxJumps;
        myAnim = GetComponent<Animator>();
    }

    void Update()
    {
        Run();
        Flip();
        //Attack();

        if (Input.GetKeyDown(KeyCode.Space) && jumpsRemaining > 0)
        {
            Jump();
        }
    }
    //void Attack()
    //{
        //if(Input.GetButtonDown("Attack"))
        //{  
            //myAnim.SetTrigger("Attack");
        //}
    //}

    void Run()
    {
        float moveDir = Input.GetAxis("Horizontal");
        Vector2 playerVel = new Vector2(moveDir * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVel;
        bool playerHasXAisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnim.SetBool("Run", playerHasXAisSpeed);

    }
    void Flip()
    {
        bool playerHasXAisSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        if(playerHasXAisSpeed)
        {
            if(myRigidbody.velocity.x > 0.1f)
            {
                transform. localRotation = Quaternion.Euler(0, 0, 0);
            }

            if(myRigidbody.velocity.x < -0.1f)
            {
                transform. localRotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }

    void Jump()
    {
        myRigidbody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        jumpsRemaining--;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumpsRemaining = maxJumps;
        }
    }
}
