using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private bool facingRight = false;
    private Rigidbody2D rb2d;
    private GameObject player;

    [SerializeField] private float movementSpeed = 10f;


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    private void Update()
    {

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
}
