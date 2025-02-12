using UnityEngine;
using UnityEngine.Animations;


public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 8f; //Default move speed (can be changed)
    public float jumpForce = 10f; 
    
    private Animator animator;
    private Rigidbody2D rb;
    private int facingDirection; //1 for right, -1 for left
    private bool isGrounded;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    //Method to handle all movement 
    void HandleMovement()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * movementSpeed, rb.linearVelocity.y);

        float speed = Mathf.Abs(rb.linearVelocity.x);
        animator.SetFloat("Speed", speed);

        if(moveInput != 0)
        {
            facingDirection = moveInput > 0 ? 1 : -1;
            transform.localScale = new Vector3(facingDirection, 1, 1);
        }

        else
        {
            transform.localScale = new Vector3(facingDirection, 1, 1);
        }
    }
    
    //Method to handle jumping
    void HandleJumping()
    {
        float jumpInput = Input.GetAxisRaw("Jump");

        if(jumpInput > 0 && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
            animator.SetBool("isJumping", true);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
            Debug.Log("Player is on the ground");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
            Debug.Log("Player is not on the ground");
        }
    }

    public void Update()
    {
        HandleMovement();
        HandleJumping();
    }
}
