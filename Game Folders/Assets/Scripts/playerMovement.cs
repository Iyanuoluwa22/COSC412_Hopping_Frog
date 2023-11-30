using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    private Rigidbody2D rb;// Declares variable rb of type Rigidbody2D
    private BoxCollider2D collide; // Declares variable collide of type BoxCollider2D
    private float HorizontalSpeed, jumpHeight, frogMass = 22.7f;
    public bool onGround;
    private GameObject platform;

    void awake()
    {
        collide = GetComponent<BoxCollider2D>(); //Gets This Objects Collider component
        rb = GetComponent<Rigidbody2D>(); //Gets This Objects Rigidbody component
    }

    private void Start()
    {
        collide = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        GameObject platform = GameObject.Find("Platform");
        onGround = true;

        HorizontalSpeed = 100f * Time.deltaTime;
        jumpHeight = 7500f * Time.deltaTime;
        rb.mass = frogMass; // Mass of a Adult Male Frog
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetButton("space")) && onGround == true)
        {
            //Move the Rigidbody upwards constantly at speed you define (the green arrow axis in Scene view)
            rb.velocity = transform.up * jumpHeight;
            onGround = false;
        }
        else if (Input.GetButton("Horizontal"))
        {
            //rb.velocity = new Vector2(Input.GetAxis("Horizontal") * playerSpeed,0);
            transform.Translate(Input.GetAxis("Horizontal") * HorizontalSpeed, 0, 0);
        }
    }


    void OnCollisionEnter2D(Collision2D collision) //this function makes sure that when the ball is touching the ground then onGround is true
    {
        if (collision.gameObject.tag == "Platform") //can also use game.Object.tag if you want to tag multiple objects without changing their names
        {
            onGround = true;
        }
    }

}
