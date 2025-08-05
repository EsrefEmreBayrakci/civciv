using UnityEngine;

public class holyWheat : MonoBehaviour, ICollectible
{

    [SerializeField] playerContrroller playerContrroller;
    [SerializeField] WheatDesignOS wheatDesignOS;

    public void collect()
    {
        playerContrroller.setJumpForce(wheatDesignOS.increasDecreaseMultiplier, wheatDesignOS.resetDuration);
        Destroy(gameObject);
    }
}
