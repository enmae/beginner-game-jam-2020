using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float scrollSpeed;
    public float horizontalAcceleration;
    public float jumpForce;
    public float jetPackForce;
    private Rigidbody2D rb;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(scrollSpeed, 0f);
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        // I added a ground tag to the ground so you can check if it's ground
        if (col.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Handles Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }

        // When you press space the jetpack will do nothing if you're falling
        // down really fast so you need to decrease the velocity
        if (Input.GetKeyDown(KeyCode.Space) && !isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.3f);
        }
    }

    void FixedUpdate() {
        
        //Handles Jetpack
        if (Input.GetKey(KeyCode.Space)) {
            // the faster you're already moving the less force it adds
            rb.AddForce(transform.up * (jetPackForce - rb.velocity.y * 0.008f), ForceMode2D.Impulse);
        }
        //Handles Horizontal Acceleration after stopping
        if (rb.velocity.x < scrollSpeed)
        {
            rb.AddForce(transform.right * horizontalAcceleration, ForceMode2D.Impulse);
        }
    }
}
