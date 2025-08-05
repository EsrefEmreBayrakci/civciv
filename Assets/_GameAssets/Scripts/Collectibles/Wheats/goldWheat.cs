using UnityEngine;

public class goldWheat : MonoBehaviour, ICollectible
{
    [SerializeField] playerContrroller playerContrroller;

    [SerializeField] WheatDesignOS wheatDesignOS;


    public void collect()
    {
        playerContrroller.setMovementSpeed(wheatDesignOS.increasDecreaseMultiplier, wheatDesignOS.resetDuration);
        Destroy(gameObject);
    }
}
