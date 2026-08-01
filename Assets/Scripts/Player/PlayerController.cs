using UnityEngine;

/// <summary>
/// Responsible for taking input and applying it to the rigid body component of the player object.
/// </summary>
[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D), typeof(SpriteRenderer))]
[RequireComponent (typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float jumpForce = 5f;



    
    private Rigidbody2D rb;
    private Collider2D col;
    private SpriteRenderer sr;

    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private float groundCheckRadius = 0.2f;

    private Vector2 groundCheckPos => CalculateGroundCheckPos();
    private bool isGrounded;

    private Vector2 CalculateGroundCheckPos()
    {
        Bounds bounds = col.bounds;
        return new Vector2(bounds.center.x, bounds.min.y);
    }

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
        //anim = Getcomponent<Animator>();

        rb.linearVelocity = Vector2.zero;

        //if (groundCheckTransform == null)
        //{
        //    Debug.LogError("Ground chwck transform is not assigned in the inspector.");
        //    groundCheckTransform = new GameObject("GroundCheck").transform;
         //   groundCheckTransform.SetParent(transform);
        //    groundCheckTransform.localPosition = Vector3.zero;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPos, groundCheckRadius, groundLayer);

        float horizontalInput = Input.GetAxis("Horizontal");

        float moveX = horizontalInput * speed;

        rb.linearVelocityX = moveX;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForceY(jumpForce, ForceMode2D.Impulse);
        }

        SpriteFlip(horizontalInput);
    }

    private void SpriteFlip(float horizontalInput) => sr.flipX = (horizontalInput < 0);
    //{
    //    if (sr.flipX && horizontalInput > 0 || !sr.flipX && horizontalInput < 0)
    //    {
    //        sr.flipX = !sr.flipX;
    //    }
   // }
}
