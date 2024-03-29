using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;

    public float PlayerSpeed = 5f;

    private float moveX;

    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        moveX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveX * PlayerSpeed, rb.velocity.y);

        if (moveX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        else if (moveX<0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }



    
}
