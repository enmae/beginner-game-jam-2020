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
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Handles Jumping
        if (Input.GetKey(KeyCode.Space) && isGrounded) {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + jumpForce);
            isGrounded = false;
        }
    }

    void FixedUpdate() {
        //Handles Jetpack
        if (Input.GetKey(KeyCode.Space)) {
            rb.AddForce(transform.up * jetPackForce, ForceMode2D.Impulse);
        }
        // Handles Horizontal Acceleration after stopping
        if (rb.velocity.x < scrollSpeed) {
            rb.AddForce(transform.right * horizontalAcceleration, ForceMode2D.Impulse);
        }
    }
}
