using UnityEngine;

[RequireComponent(typeof(catStateController))]
public class CatAnimationController : MonoBehaviour
{
    [SerializeField] Animator anim;
    private catStateController stateController;

    private void Awake()
    {
        stateController = GetComponent<catStateController>();
    }

    private void Update()
    {
        if (anim == null || stateController == null) return;

        // tüm bool parametreleri kapat
        anim.SetBool("IsIdling", false);
        anim.SetBool("IsWalking", false);
        anim.SetBool("IsRunning", false);
        anim.SetBool("IsAttacking", false);

        switch (stateController.getCurrentState())
        {
            case catState.Idle:
                anim.SetBool("IsIdling", true);
                break;
            case catState.Walking:
                anim.SetBool("IsWalking", true);
                break;
            case catState.Running:
                anim.SetBool("IsRunning", true);
                break;
            case catState.Attacking:
                anim.SetBool("IsAttacking", true);
                break;
        }
    }
}
