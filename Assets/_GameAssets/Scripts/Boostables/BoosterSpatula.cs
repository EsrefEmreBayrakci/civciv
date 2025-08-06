using UnityEngine;

public class BoosterSpatula : MonoBehaviour, IBoostable
{
    [SerializeField] float jumpForce;

    [SerializeField] Animator animator;

    private bool isActive;

    public void Boost(playerContrroller playerContrroller)
    {
        if (isActive) return;

        PlayAnimation();
        Rigidbody rb = playerContrroller.getPlayerRB();

        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);

        rb.AddForce(transform.forward * jumpForce, ForceMode.Impulse);
        isActive = true;
        Invoke("ResetActive", 0.2f);

    }

    public void PlayAnimation()
    {
        animator.SetTrigger("IsSpatulaJumping");
    }

    void ResetActive()
    {
        isActive = false;
    }
}
