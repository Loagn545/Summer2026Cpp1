using UnityEngine;

/// <summary>
/// Responsible for taking input and applying it to the rigid body component of the player object.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float jumpForce = 5f;


    [SerializeField]
    private Rigidbody2D rb;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.linearVelocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()   
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        float moveX = horizontalInput * speed;

        rb.linearVelocityX = moveX;

        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForceY(jumpForce, ForceMode2D.Impulse);
        }
    }
}
