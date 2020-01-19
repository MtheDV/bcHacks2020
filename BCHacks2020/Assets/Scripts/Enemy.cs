using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool facingRight = false;
    private Rigidbody2D rb2d;
    private GameObject player;

    private bool isHit = false;
    private int hitCounter = 0;

    private int health = 3;
    private bool follow = false;

    public Animator animator;

    [SerializeField] public float movementSpeed = 10f;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (!isHit) {
            if (follow) {
                if (facingRight == false)
                {
                    if (transform.position.x > player.transform.position.x)
                    {
                        rb2d.velocity = new Vector2(-movementSpeed, 0);
                    }
                    else
                    {
                        facingRight = true;
                    }
                }
                else
                {
                    if (transform.position.x < player.transform.position.x)
                    {
                        rb2d.velocity = new Vector2(movementSpeed, 0);
                    }
                    else
                    {
                        facingRight = false;
                    }
                }
            }

            if (rb2d.velocity.x < 0 && facingRight)
                flipEnemy();
            else if (rb2d.velocity.x > 0 && !facingRight)
                flipEnemy();
        } else {
            hitCounter--;
            if (hitCounter <= 0)
                isHit = false;
        }

        if (health <= 0) {
            Destroy(gameObject);
        }
    }

    void flipEnemy() {
        facingRight = !facingRight;
        Vector3 flipScale = transform.localScale;
        flipScale.x *= -1;
        transform.localScale = flipScale;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player" && collision.gameObject.tag != "PlayerAttack")
        {
            if (!isHit) {
                int leftRightPush = -1;
                if (facingRight)
                    leftRightPush = 1;
                collision.gameObject.GetComponent<PlayerController>().KnockBack(new Vector2(leftRightPush * 7500, 500));
            }
        }
    }

    public void Follow() {
        follow = true;
    }

    public void KnockBack(Vector2 force) {
        rb2d.AddForce(force);
        isHit = true;
        hitCounter = 50;
        health--;
        animator.SetTrigger("hurtStart");
    }
}
