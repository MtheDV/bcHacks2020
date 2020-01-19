using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    public int collectables = 0;

    public Animator playerAnimator;

    public TextMeshProUGUI collectiblesText;

    private List<GameObject> health;
    public GameObject healthImage;
    private int healthAmount = 4;
    public GameObject canvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collectables")
        {
            Destroy(collision.gameObject);
            collectables++;
        }
    }
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
        health = new List<GameObject>();
        for(int i = 0; i < 4; i++) {
            float x, y;
            x = 100 * i + 64;
            y = -61;
            GameObject newHealth = Instantiate(healthImage) as GameObject;
            newHealth.transform.position = new Vector2(x, y);
            newHealth.transform.SetParent(canvas.transform, false);
            health.Add(newHealth);
        }
        Destroy(healthImage);
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

        if (Input.GetMouseButtonDown(0) && isGrounded) {
            playerAnimator.SetTrigger("punchStart");
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

        collectiblesText.text = collectables.ToString();

        if (healthAmount <= 0) {
            Destroy(gameObject);
            // end game
        }
    }

    void flipPlayer() {
        facingRight = !facingRight;
        Vector3 flipScale = transform.localScale;
        flipScale.x *= -1;
        transform.localScale = flipScale;
    }

    public void KnockBack(Vector2 force) {
        rbody.AddForce(force);
        playerAnimator.SetTrigger("hurtStart");
        healthAmount--;
        Destroy(health[health.Count-1]);
        health.Remove(health[health.Count-1]);
    }
}
