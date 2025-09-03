using System;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class playerContrroller : MonoBehaviour
{
    public event Action OnJump;
    public event Action<playerState> OnPlayerStateChanged;

    [Header("Referans")]
    [SerializeField] Transform orientationTransform;
    public CatController cat;

    [Header("Hareket Ayarları")]
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] KeyCode movementKeyCode;

    private Rigidbody rb;
    float horizontalInput, verticalInput;


    [Header("Zıplama Ayarları")]
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float airMultiplier;
    [SerializeField] float jumpDrag;
    [SerializeField] public bool zipladiMi;
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

    float _moveSpeed;
    float _jumpForce;

    public bool IsOnFloor { get; private set; } = false;



    void Awake()
    {
        stateController = GetComponent<stateController>();
        rb = GetComponent<Rigidbody>();

        _moveSpeed = moveSpeed;
        _jumpForce = jumpForce;
    }

    void Update()
    {
        if (GameManager.Instance.currentGameState != gameState.play && GameManager.Instance.currentGameState != gameState.resume)
        {
            return;
        }

        setInput();
        setState();
        playerDrag();
        playerHizLimit();

    }

    void FixedUpdate()
    {
        if (GameManager.Instance.currentGameState != gameState.play && GameManager.Instance.currentGameState != gameState.resume)
        {
            return;
        }

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
            OnPlayerStateChanged?.Invoke(newState);
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
        OnJump?.Invoke();
        // Y eksenindeki hızı sıfırla
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            IsOnFloor = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Floor"))
        {
            IsOnFloor = false;
        }
    }

    #region  Helpers
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

    public void setMovementSpeed(float speed, float duration)
    {
        moveSpeed += speed;
        Invoke("resetMoveSpeed", duration);
    }

    void resetMoveSpeed()
    {
        moveSpeed = _moveSpeed;
    }

    public void setJumpForce(float force, float duration)
    {
        jumpForce += force;
        Invoke("resetJumpForce", duration);
    }

    void resetJumpForce()
    {
        jumpForce = _jumpForce;
    }

    public Rigidbody getPlayerRB()
    {
        return rb;
    }

    public Transform getPlayerTransform()
    {
        return orientationTransform;
    }

    #endregion
}
