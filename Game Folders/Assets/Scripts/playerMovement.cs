using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D rb;// Declares variable rb of type Rigidbody2D
    private BoxCollider2D collide; // Declares variable collide of type BoxCollider2D
    private static float HorizontalSpeed, jumpHeight, frogMass = 22.7f, scale;
    private bool onGround;
    private GameObject platform;
    public Animator animator;

    void awake()
    {
        rb.freezeRotation = true;
        onGround = true;
        HorizontalSpeed = 125f * Time.deltaTime;
        jumpHeight = 7500f * Time.deltaTime;
    }

    private void Start()
    {
        collide = GetComponent<BoxCollider2D>(); //Gets This Objects Collider component
        rb = GetComponent<Rigidbody2D>(); //Gets This Objects Rigidbody component
        rb.mass = frogMass; // Mass of a Adult Male Frog
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        HorizontalSpeed = 125f * Time.deltaTime;
        jumpHeight = 7500f * Time.deltaTime;
        animator.SetFloat("Speed", 0);
        rb.freezeRotation = false;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Discrete;
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetButton("space")) && onGround == true)
        {
            //Move the Rigidbody upwards constantly at speed you define (the green arrow axis in Scene view)
            rb.velocity = transform.up * jumpHeight;
            animator.SetBool("isJumping", true);
            onGround = false;
            if (onGround == false)
            {
                transform.rotation = new Quaternion(0, 0, 0,0);
                rb.freezeRotation = true;
            }
        }
        else if (Input.GetButton("Horizontal"))
        {
            //rb.velocity = new Vector2(Input.GetAxis("Horizontal") * playerSpeed,0);
            transform.Translate(Input.GetAxis("Horizontal") * HorizontalSpeed, 0, 0);
            if (Input.GetAxis("Horizontal")< 0f)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            } else
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            animator.SetFloat("Speed", HorizontalSpeed);
            rb.freezeRotation = true;
        }
    }


    void OnCollisionEnter2D(Collision2D collision) //this function makes sure that when the ball is touching the ground then onGround is true
    {
        if (collision.gameObject.tag == "Platform") //can also use game.Object.tag if you want to tag multiple objects without changing their names
        {
            onGround = true;
            rb.rotation = collision.gameObject.transform.localEulerAngles.z;
            Debug.Log(rb.rotation);
            rb.freezeRotation = true;
            animator.SetBool("isJumping", false);
        }
    }

}
