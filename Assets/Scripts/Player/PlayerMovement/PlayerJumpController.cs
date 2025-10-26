using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerJumpController : MonoBehaviour
{
    public float jumpForce;
    [Header("Grounding")]
    public LayerMask groundMask;
    public float groundRayLength = 0.1f;
    public int numRaycasts = 1;
    public float playerModelSize;
    public bool IsGrounded = false;

    

    private Rigidbody2D playerRigidbody;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float verticalVelocity = playerRigidbody.linearVelocityY;

        checkGrounded();
        // Debug.Log(IsGrounded);

        bool inputJump = Input.GetKeyDown(KeyCode.Space);
        if (inputJump && IsGrounded)
        {
            verticalVelocity = jumpForce;
        }

        playerRigidbody.linearVelocityY = verticalVelocity;
    }

    private void checkGrounded()
    {
        IsGrounded = false;
        for (float i = 0; i <= playerModelSize; i += playerModelSize / numRaycasts)
        {
            float raycastOrigin = i - playerModelSize / 2;
            Vector3 rayStart = transform.position + Vector3.right * raycastOrigin;
            Debug.DrawLine(rayStart, rayStart + Vector3.down * groundRayLength, Color.red);
            RaycastHit2D hit = Physics2D.Raycast(rayStart, Vector3.down, groundRayLength, groundMask);
            if (hit.collider != null)
            {
                IsGrounded = true;
                // Debug.Log("grounded");
                return;
            }
        }
        // Debug.Log("not grounded");
    }

    
}
