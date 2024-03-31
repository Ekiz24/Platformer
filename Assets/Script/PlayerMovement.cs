using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;


public class PlayerMovement : MonoBehaviour
{

    public float runSpeed = 10f;
    public float jumpSpeed = 20f;
    public float acceleration = 20f; 
    public float deceleration = 20f; 

    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    public CapsuleCollider2D myBodyCollider;
    public BoxCollider2D myFeetCollider;
    public GameObject dialog;
    public AudioSource whisper;

    float gravityScaleAtStart;
    bool isAlive = true;
    int points = 0;
    int checkpoints = 0;

    [SerializeField] private TextMeshProUGUI pointsText;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();

        gravityScaleAtStart = myRigidbody.gravityScale;

         dialog.SetActive(false);
    }

    void Update()
    {
        if (!isAlive) { return; }
        Run();
        FlipSprite();

        if (Input.anyKeyDown)
        {
            dialog.SetActive(false);
        }

           

    }

    void OnMove(InputValue value)
    {
        if (!isAlive) { return; }
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (!isAlive) { return; }
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Platforms")))
        {
            return;
        }
        if (value.isPressed)
        {
            myRigidbody.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    void Run()
    {
        float targetVelocityX = moveInput.x * runSpeed;
        float currentVelocityX = myRigidbody.velocity.x;

        // Adjustment of speed (acceleration and deceleration)
        if (moveInput.x != 0)
        {
            currentVelocityX = Mathf.MoveTowards(currentVelocityX, targetVelocityX, acceleration * Time.deltaTime);
        }
        else
        {
            currentVelocityX = Mathf.MoveTowards(currentVelocityX, 0f, deceleration * Time.deltaTime);
        }

        myRigidbody.velocity = new Vector2(currentVelocityX, myRigidbody.velocity.y);

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", playerHasHorizontalSpeed);
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody.velocity.x), 1f);
        }
    }
         public void ClosingDialog()
     {
         dialog.SetActive(false);
     }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //collect lights
        if (collision.gameObject.CompareTag("Light"))
        {
            points++;
            pointsText.SetText("Points:" + points);

        }

        //collect checkpoints for reborning in the right place
        if (collision.gameObject.CompareTag("CheckPoints"))
        {
            checkpoints++;
            Destroy(collision.gameObject);

        }

        //touch the ShadowMan
        if(collision.gameObject.CompareTag("ShadowMan"))
        {
            Die();
        }
        //touch the prisoner

        if(collision.gameObject.CompareTag("prisoner"))
        {
            dialog.SetActive(true); 
        }
        //touch the whisper trigger
        if (collision.gameObject.CompareTag("whisper"))
        {
            whisper.Play();
            Destroy(collision.gameObject);
        }


    }
    void Die()
    {

           isAlive = false;
            
            switch(checkpoints)
            {
            case 1:
                transform.position = new Vector3(29.71f, 4.33f, 1f);
                isAlive = true;
                break;
            case 2:
                transform.position = new Vector3(12.66f, 18.11f, 1f);
                isAlive = true;
                break;
            case 3:
                transform.position = new Vector3(47.67f, 9.13f, 1f);
                isAlive = true;
                break;
            case 4:
                transform.position = new Vector3(58.54f, 22.12f, 1f);
                isAlive = true;
                break;
            case 5:
                transform.position = new Vector3(39.08f, 31.04f, 1f);
                isAlive = true;
                break;


            default:
                    transform.position = new Vector3(-10, -2.99f, 1f);
                    isAlive = true;
                    break;

            }
        
    }
}
