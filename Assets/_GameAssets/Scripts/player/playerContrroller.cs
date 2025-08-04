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
    [SerializeField] float airMultiplier;
    [SerializeField] float jumpDrag;
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
    private stateController stateController;
    Vector3 movementDirection;





    void Awake()
    {
        stateController = GetComponent<stateController>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        setInput();
        setState();
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

    void setState()
    {
        var movementDirection = getDirection();
        var yerdeMi = isGrounded();
        var currentState = stateController.getState();

        var newState = currentState switch
        {
            _ when movementDirection == Vector3.zero && yerdeMi && !kayiyorMu => playerState.idle,
            _ when movementDirection != Vector3.zero && yerdeMi && !kayiyorMu => playerState.move,
            _ when movementDirection != Vector3.zero && yerdeMi && kayiyorMu => playerState.slide,
            _ when movementDirection == Vector3.zero && yerdeMi && kayiyorMu => playerState.slideIdle,
            _ when !zipladiMi && !yerdeMi => playerState.jump,
            _ => currentState


        };

        if (currentState != newState)
        {
            stateController.changeState(newState);
        }

    }

    void playerMovement()
    {
        movementDirection = orientationTransform.forward * verticalInput + orientationTransform.right * horizontalInput;

        float forceMultiplier = stateController.getState() switch
        {
            playerState.move => 1f,
            playerState.slide => slideSpeed,
            playerState.jump => airMultiplier,
            _ => 1f
        };

        rb.AddForce(movementDirection.normalized * moveSpeed * forceMultiplier, ForceMode.Force);

    }

    void playerDrag()
    {
        rb.linearDamping = stateController.getState() switch
        {
            playerState.move => groundDrag,
            playerState.slide => slideDrag,
            playerState.jump => jumpDrag,
            _ => rb.linearDamping
        };


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

    private Vector3 getDirection()
    {
        return movementDirection.normalized;
    }
}
