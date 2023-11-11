using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator animator;
    private bool canJump = true;
    public float maxSpeed = 10.0f;
    public float moveSpeed = 1.0f;
    public float jumpForce = 100.0f;
    public int velocityYRaw = -1;
    public Vector3 startPos;

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

        rb.AddForce(Input.GetAxisRaw("Horizontal") * Vector2.right * moveSpeed * Time.deltaTime);

        if (Mathf.Abs(rb.velocity.x) >= maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed * Mathf.Sign(rb.velocity.x), rb.velocity.y);
        }

        bool checkGround = CheckGround();

        // Jump Animation
        if (!checkGround && rb.velocity.y > 0.1 && velocityYRaw != 1)
        {
            velocityYRaw = 1;
            animator.SetTrigger("Up");
        }
        else if (!checkGround && rb.velocity.y < -0.1 && velocityYRaw != -1)
        {
            velocityYRaw = -1;
            animator.SetTrigger("Down");
        }
        else if (checkGround && velocityYRaw != 0)
        {
            velocityYRaw = 0;
            animator.SetTrigger("Middle");
        }

        // Jump
        if (Input.GetAxisRaw("Vertical") > 0 && checkGround && canJump)
        {
            StartCoroutine(JumpDelay());
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce);
        }

        //reset
        if (transform.position.y < -15f || Input.GetKey(KeyCode.R))
        {
            transform.position = startPos;
        }
    }

    public bool CheckGround()
    {
        float distanceToTheGround = GetComponent<Collider2D>().bounds.extents.y;
        //return Physics2D.BoxCast(
        //    new Vector2(transform.position.x, transform.position.y),
        //    new Vector2(1f,0.2f),
        //    0f,
        //    Vector2.down,
        //    distanceToTheGround + 0.05f,
        //    LayerMask.GetMask("Floor")
        //);
        return BoxCastDrawer.BoxCastAndDraw(
            new Vector2(transform.position.x, transform.position.y),
            new Vector2(0.8f, 0.02f),
            0f,
            Vector2.down,
            distanceToTheGround,
            LayerMask.GetMask("Floor")
        );
    }

    IEnumerator JumpDelay()
    {
        canJump = false;
        yield return new WaitForSeconds(0.7f);
        canJump = true;
    }
}
