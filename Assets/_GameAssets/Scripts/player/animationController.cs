using System;
using UnityEngine;

public class animationController : MonoBehaviour
{
    [SerializeField] Animator animator;

    private playerContrroller playerContrroller;
    private stateController stateController;

    void Awake()
    {
        stateController = GetComponent<stateController>();
        playerContrroller = GetComponent<playerContrroller>();
    }

    void Start()
    {
        playerContrroller.OnJump += playerContrroller_OnJump;
    }

    private void playerContrroller_OnJump()
    {
        animator.SetBool(Consts.PlayerAnimastions.IS_JUMPING, true);
        Invoke("ResetJump", 0.5f);
    }

    void ResetJump()
    {
        animator.SetBool(Consts.PlayerAnimastions.IS_JUMPING, false);
    }

    void Update()
    {
        if (GameManager.Instance.currentGameState != gameState.play && GameManager.Instance.currentGameState != gameState.resume)
        {
            return;
        }
        setPlayerAnimastions();
    }



    void setPlayerAnimastions()
    {
        var currentState = stateController.getState();

        switch (currentState)
        {
            case playerState.idle:
                animator.SetBool(Consts.PlayerAnimastions.IS_SLIDING, false);
                animator.SetBool(Consts.PlayerAnimastions.IS_MOVING, false);
                break;

            case playerState.move:
                animator.SetBool(Consts.PlayerAnimastions.IS_SLIDING, false);
                animator.SetBool(Consts.PlayerAnimastions.IS_MOVING, true);
                //animator.SetBool(Consts.PlayerAnimastions.IS_JUMPING, false);
                break;

            case playerState.slide:
                animator.SetBool(Consts.PlayerAnimastions.IS_SLIDING, true);
                animator.SetBool(Consts.PlayerAnimastions.IS_SLIDING_ACTIVE, true);
                break;

            case playerState.slideIdle:
                animator.SetBool(Consts.PlayerAnimastions.IS_SLIDING, true);
                animator.SetBool(Consts.PlayerAnimastions.IS_SLIDING_ACTIVE, false);
                break;
        }
    }
}
