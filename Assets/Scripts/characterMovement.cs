using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float scrollSpeed;
    public float horizontalAcceleration;
    public float jetPackForce;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    private bool isGrounded = false;
    public Animator anim;
    private bool isFlipped = false;

    void Start()
    {
        rb.velocity = new Vector2(scrollSpeed, 0f);
    }

    // im doing this instead of the typical oncollisionenter because you can run
    // on floating platforms and not just the ground
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!isGrounded && collision.gameObject.CompareTag("Ground") && rb.velocity.y == 0)
        {
            isGrounded = true;
            anim.SetBool("isRunning", true);
            anim.SetBool("isFlying", false);
            anim.SetBool("isFalling", false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // When you press space the jetpack will do nothing if you're falling
        // down really fast so you need to decrease the velocity
        if (Input.GetKeyDown(KeyCode.Space) && !isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.3f);
        }

        // handles gravity
        if (transform.position.y < 15)
        {
            sr.flipY = false;
            isFlipped = false;
            Physics2D.gravity = new Vector2(0, Mathf.Abs(Physics2D.gravity.y) * -1);
        }
        else
        {
            sr.flipY = true;
            isFlipped = true;
            Physics2D.gravity = new Vector2(0, Mathf.Abs(Physics2D.gravity.y));
        }
    }

    void FixedUpdate() {
        
        //Handles Jetpack
        if (Input.GetKey(KeyCode.Space)) {
            // the faster you're already moving the less force it adds
            if (isFlipped)
            {
                rb.AddForce((transform.up * -1) * (jetPackForce - (rb.velocity.y * -1) * 0.008f), ForceMode2D.Impulse);
            }
            else
            {
                rb.AddForce(transform.up * (jetPackForce - rb.velocity.y * 0.008f), ForceMode2D.Impulse);
            }
            
            anim.SetBool("isFlying", true);
            anim.SetBool("isFalling", false);
            anim.SetBool("isRunning", false);
        } else if (!isGrounded)
        {
            anim.SetBool("isFalling", true);
            anim.SetBool("isRunning", false);
            anim.SetBool("isFlying", false);
        }

        //Handles Horizontal Acceleration after stopping
        if (rb.velocity.x < scrollSpeed)
        {
            rb.AddForce(transform.right * horizontalAcceleration, ForceMode2D.Impulse);
        }
    }

}
