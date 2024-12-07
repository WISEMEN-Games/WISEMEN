using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of horizontal and vertical movement
    public float jumpSpeed = 10f; // Jump velocity
    private bool facingRight = true;
    public Animator animator;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovePlayer();
        float speed =rb.linearVelocity.magnitude;
        animator.SetFloat("speed",speed );
        FlipPlayer();
    }

    void MovePlayer()
    {
        // Get input for horizontal and vertical movement
        float moveX = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right
        float moveY = Input.GetAxisRaw("Vertical"); // W/S or Up/Down

        // Set the velocity for horizontal and vertical movement
        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocity.y);

        // For vertical aerial movement (optional, remove if not needed)
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, moveY * moveSpeed);

    }
    void FlipPlayer()
    {
        // Check the horizontal velocity direction
        float moveX = Input.GetAxisRaw("Horizontal");

        if (moveX > 0 && !facingRight) // Moving right but facing left
        {
            Flip();
        }
        else if (moveX < 0 && facingRight) // Moving left but facing right
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight; // Toggle the direction
        Vector3 scale = transform.localScale;
        scale.x *= -1; // Flip the X-axis
        transform.localScale = scale;
    }

}

