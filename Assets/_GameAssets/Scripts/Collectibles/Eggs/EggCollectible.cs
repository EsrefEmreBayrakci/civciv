using Unity.Cinemachine;
using UnityEngine;

public class EggCollectible : MonoBehaviour, ICollectible
{
    private bool isCollected = false;

    [System.Obsolete]
    public void collect()
    {
        if (isCollected) return;

        AudioManager.Instance.Play(SoundType.PickupGoodSound);

        isCollected = true;

        CameraShakeController.Instance.Shake(new Vector3(0f, -0f, -0.4f), 0.7f, 1f, CinemachineImpulseDefinition.ImpulseShapes.Bump);


        Destroy(gameObject);
        GameManager.Instance.CollectEgg();
    }


}
