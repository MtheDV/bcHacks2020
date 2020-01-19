using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public Transform playerTransform;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Enemey")
        {
            collision.gameObject.GetComponent<Enemy>().KnockBack(new Vector2(playerTransform.localScale.x * 1500, 500));
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
