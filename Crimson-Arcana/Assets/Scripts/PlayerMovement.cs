using UnityEngine;
using UnityEngine.Animations;


public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 8f; //Default move speed (can be changed)
    
    private Animator animator;
    private Rigidbody2D rb;
    private int facingDirection; //1 for right, -1 for left
    private bool isGrounded;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    public void Update()
    {
        HandleMovement();
    }
}
