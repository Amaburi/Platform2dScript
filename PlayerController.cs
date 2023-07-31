using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Rigidbody2D rb;
    public Animator animator;
    public GroundCheck groundCheck;
    public SpriteRenderer spriteRenderer;
    public bool isAttacking = false;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        groundCheck = GetComponentInChildren<GroundCheck>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Set animator parameters for animations.
        animator.SetBool("IsRunning", Mathf.Abs(moveInput) > 0.1f);
        animator.SetBool("IsJumping", !IsGrounded());
        animator.SetBool("IsFall", rb.velocity.y < -0.1f);

        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                animator.SetBool("IsJumping", true);
            }
        }
        if (Input.GetButtonDown("Attack") && !isAttacking && IsGrounded())
        {
            // Trigger the attack animation
            animator.SetBool("IsAttacking", true);
            isAttacking = true;
        }
        // Flip the sprite horizontally based on movement direction.
        if (moveInput < 0)
        {
            spriteRenderer.flipX = true; // Flip the sprite when moving left.
        }
        else if (moveInput > 0)
        {
            spriteRenderer.flipX = false; // Set back to normal when moving right.
        }
    }

    public void FinishAttackAnimation()
    {
        // Reset the attack animation parameter to false when the attack animation finishes
        animator.SetBool("IsAttacking", false);
        isAttacking = false;
    }
    public bool IsGrounded()
    {
        return groundCheck.IsGrounded();
    }
}
