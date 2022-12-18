using UnityEngine;

public class Zack : MonoBehaviour
{
    [Header("Movement")]
    public int speed;

    [Header("Raycast")]
    public Transform groundCheck;//origin raycast point
    public LayerMask groundLayer;//Layer where the ground will be contained
    public float rayLength;//ray Length
    public bool isGrounded;//var which indicates if we are or not touching the ground

    [Header("Jump")]
    public float jumpForce;

    [Header("Win")]
    public float timeForWinning;

    Rigidbody2D rb2D;
    SpriteRenderer spriteRenderer;
    Animator anim;

    bool isAttackAnimRunning;
    bool canMove;
    float timer;
    bool jumpPressed; //Tells me if I can jump or not
    float h;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        //lastDirSense = spriteRenderer.flipX;
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        CheckRunningAnim();
        //if (!isAttackAnimRunning && !isWinningAnimRunning)
        //{
        Movement();
        Flip();
        Animating();
        IsGrounded();
        JumpPressed();
        //}
        Attack();
        Win();
    }
    void FixedUpdate()
    {
        if (jumpPressed)
            Jump();
    }
    void CheckRunningAnim()
    {
        isAttackAnimRunning = anim.GetCurrentAnimatorStateInfo(0).IsName("ZackAttack");
        //isWinningAnimRunning = anim.GetCurrentAnimatorStateInfo(0).IsName("ZackWin");
    }
    void Jump()
    {
        jumpPressed = false;
        if (canMove)
            rb2D.AddForce(Vector2.up * jumpForce);
    }
    void JumpPressed()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) jumpPressed = true;
    }
    void IsGrounded()
    {
        //I launch a selective raycast (only detects the objects in the Ground Layer). 
        //It has rayLength as length, groundCheck as origin, down-Y direction.
        //The raycast return true if it is touching an object of the ground Layer
        isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, rayLength, groundLayer);
        Debug.DrawRay(groundCheck.position, Vector2.down * rayLength, Color.red);
    }
    void Movement()
    {
        h = Input.GetAxis("Horizontal");
        
        if (canMove)
            transform.Translate(h * Vector2.right * speed * Time.deltaTime);
    }
    void Flip()
    {
        //If I go to the right
        if (h > 0) spriteRenderer.flipX = true;
        //If I go to the left
        else if (h < 0) spriteRenderer.flipX = false;
    }
    void Animating()
    {
        if (h != 0) anim.SetBool("IsMoving", true);
        else anim.SetBool("IsMoving", false);

        //IsJumping param. will take the NOT value of isGrounded
        anim.SetBool("IsJumping", !isGrounded);
    }
    void Attack()
    {
        //If I press the mouse button and the player is not moving
        if (Input.GetMouseButtonDown(0) && h == 0)
        {
            canMove = false;
            anim.SetTrigger("Attack");
        }
    }
    void Win()
    {
        //As long as the player is stopped and not jumping and the attack anim. is not running
        //then the timer will keep running
        if (h == 0 && isGrounded & !isAttackAnimRunning)
        {
            timer += Time.deltaTime;
            if (timer >= timeForWinning)
            {
                timer = 0;
                canMove = false;
                anim.SetTrigger("Win");                
            }
        }
        //Otherwise, we'll reset it
        else
            timer = 0;
    }
    void CanMoveToTrue()
    {
        canMove = true;
    }
}
