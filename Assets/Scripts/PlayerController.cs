using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator animator;
    public float maxSpeed = 50.0f;

    public float jumpForce = 10.0f;

    private bool canJump = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            animator.SetBool("isWalking", true);
            sr.flipX = false;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            animator.SetBool("isWalking", true);
            sr.flipX = true;
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        rb.AddForce(Input.GetAxisRaw("Horizontal") * Vector2.right);


        if (Mathf.Abs(rb.velocity.x) >= maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed * Mathf.Sign(rb.velocity.x), rb.velocity.y);
        }

        // Jump
        if (Input.GetAxisRaw("Vertical") > 0 && canJump)
        {
            animator.SetBool("isJumping", true);
            canJump = false;
            rb.AddForce(Vector2.up * jumpForce);
        }
    }

    private void OnCollisionStay2D(Collision2D other) {
        
        if (other.collider.CompareTag("Floor"))
        {
            animator.SetBool("isJumping", false);
            canJump = true;
        }
    }
}
