using UnityEngine;

public class playerContrroller : MonoBehaviour
{
    [Header("Referans")]
    [SerializeField] Transform orientationTransform;

    [Header("Hareket Ayarları")]
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] KeyCode movementKeyCode;

    private Rigidbody rb;
    float horizontalInput, verticalInput;


    [Header("Zıplama Ayarları")]
    [SerializeField] float jumpForce = 5f;
    [SerializeField] bool zipladiMi;
    [SerializeField] float ziplamaCooldown = 1f;



    [Header("Ground Ayarları")]
    [SerializeField] float playerHeight = 2f;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float groundDrag;

    [Header("Kayma Ayarları")]

    [SerializeField] KeyCode slideKeyCode;
    [SerializeField] float slideSpeed;
    [SerializeField] float slideDrag;

    bool kayiyorMu;





    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        setInput();
        playerDrag();
        playerHizLimit();

    }

    void FixedUpdate()
    {
        playerMovement();
    }

    void setInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(slideKeyCode))
        {
            kayiyorMu = true;
            rb.AddForce(Vector3.down * slideSpeed, ForceMode.Force);
        }

        else if (Input.GetKeyUp(movementKeyCode))
        {
            kayiyorMu = false;
        }

        else if (Input.GetKeyDown(KeyCode.Space) && zipladiMi && isGrounded())
        {
            zipladiMi = false;
            playerJump();
            Invoke("ziplamaReset", ziplamaCooldown);
        }
    }

    void playerMovement()
    {
        Vector3 inputDirection = orientationTransform.forward * verticalInput + orientationTransform.right * horizontalInput;

        if (kayiyorMu)
        {
            rb.AddForce(inputDirection.normalized * moveSpeed * slideSpeed, ForceMode.Force);

        }

        else
        {
            rb.AddForce(inputDirection.normalized * moveSpeed, ForceMode.Force);
        }

    }

    void playerDrag()
    {
        if (kayiyorMu)
        {
            rb.linearDamping = slideDrag;
        }
        else
        {
            rb.linearDamping = groundDrag;
        }


    }

    void playerHizLimit()
    {
        Vector3 duzVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        if (duzVelocity.magnitude > moveSpeed)
        {
            Vector3 limitliHiz = duzVelocity.normalized * moveSpeed;
            rb.linearVelocity = new Vector3(limitliHiz.x, rb.linearVelocity.y, limitliHiz.z);
        }
    }

    void playerJump()
    {
        // Y eksenindeki hızı sıfırla
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

    }

    void ziplamaReset()
    {
        zipladiMi = true;
    }

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundLayer);

    }
}
