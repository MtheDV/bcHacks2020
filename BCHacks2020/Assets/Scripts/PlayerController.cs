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

    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask ground;
    public float radiusCheck;

    public Animator playerAnimator;


    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
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
