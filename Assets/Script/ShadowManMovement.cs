using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowManMovement : MonoBehaviour
{
    //editable shadowman moving range
    public float range = 0.5f;

    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D myRigidbody;
    Vector2 oldPosition;
    Vector2 newPosition;

    

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        oldPosition = transform.position;
    }

    void Update()
    {
        //ChoiceA: The monster walks back and forth in a defined area
        myRigidbody.velocity = new Vector2(moveSpeed, 0f);
        newPosition = transform.position;
        float distance = Vector2.Distance(oldPosition, newPosition);
        if (distance > range)
        {
            moveSpeed = -moveSpeed;
            FlipShadowManFacing();
            oldPosition = newPosition;
        }

    }

    //Choice B: If you want the monster change direction and go back and forth when it hit the walls, then use this code.
    //void OnTriggerExit2D(Collider2D collision)
    //{
    //    moveSpeed = -moveSpeed;
    //    FlipShadowManFacing();
    //}

    void FlipShadowManFacing()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidbody.velocity.x)), 1f);
    }
}
