using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grasshopper : MonoBehaviour
{
    [Header("Jump")]
    public float forceUp;
    public float forceRight;
    public float timeToJump;

    [Header("Raycast")]
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float rayLength;
    public bool isGrounded;

    int direction;//var. which tells me if it's moving to the left or the right
    Rigidbody2D rb2D;
    Animator anim;
    SpriteRenderer spriteRenderer;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        direction = 1;
    }

    // Update is called once per frame
    void Update()
    {
        //Update jump time elapsed
        timer += Time.deltaTime;
        //Perform Jump when timeToJump time has been reached
        if (timer >= timeToJump) Jump();

        //Update isGrounded var by means of the Raycast
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, rayLength, groundLayer);

        //Update Animator params.
        Animating();
    }
    void Animating()
    {
        anim.SetFloat("YVelocity",rb2D.velocity.y);
        anim.SetBool("IsGrounded", isGrounded);
    }
    void Jump()
    {
        //Reset timer to start counting again the Jumping time
        timer = 0;
        direction *= -1;
        Flip();
        //direction = direction * -1;

        //Add up Force
        rb2D.AddForce(Vector2.up * forceUp,ForceMode2D.Impulse);
        rb2D.AddForce(Vector2.right * forceRight * direction, ForceMode2D.Impulse);
    }
    void Flip()
    {
        if (direction > 0) spriteRenderer.flipX = true;
        else spriteRenderer.flipX = false;
    }
}
