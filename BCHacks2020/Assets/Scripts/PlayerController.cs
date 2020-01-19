using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public float moveSpeed = 10.0f;
    public float jumpSpeed = 10.0f;
    private float inputtedMove;

    private Rigidbody2D rbody;

    private bool facingRight = false;

    private Enemy enemy;

    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask ground;
    public float radiusCheck;

    public Animator playerAnimator;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemey" && isGrounded == false)
        {
            Destroy(collision.gameObject);
        }
    }


    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        enemy = GameObject.Find("Enemy Ball").GetComponent<Enemy>();
    }


    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, radiusCheck, ground);

        inputtedMove = Input.GetAxis("Horizontal");
        rbody.velocity = new Vector2(inputtedMove * moveSpeed, rbody.velocity.y);

        if (inputtedMove < 0 && !facingRight)
            flipPlayer();
        else if (inputtedMove > 0 && facingRight)
            flipPlayer();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isGrounded) {
            rbody.velocity = Vector2.up * jumpSpeed;
            playerAnimator.SetTrigger("jumpStart");
        }

        if (isGrounded) {
            playerAnimator.SetBool("isJumping", false);
        }
        else {
            playerAnimator.SetBool("isJumping", true);
        }

        if (inputtedMove == 0)
            playerAnimator.SetBool("isRunning", false);
        else
            playerAnimator.SetBool("isRunning", true);
    }

    void flipPlayer() {
        facingRight = !facingRight;
        Vector3 flipScale = transform.localScale;
        flipScale.x *= -1;
        transform.localScale = flipScale;
    }
}
