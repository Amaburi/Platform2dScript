using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerController playerController; // Reference to the PlayerController script.

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>(); // Assign the reference to the PlayerController script.
    }

    void Update()
    {
        if (playerController.IsGrounded() && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * playerController.jumpForce, ForceMode2D.Impulse);
        }
    }
}
