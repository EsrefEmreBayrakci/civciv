using UnityEngine;
using Unity.Cinemachine;

public class CameraShakeController : MonoBehaviour
{
    public static CameraShakeController Instance { get; private set; }

    [Header("Cinemachine Impulse")]
    [SerializeField] private CinemachineImpulseSource impulseSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        if (impulseSource == null)
            impulseSource = GetComponent<CinemachineImpulseSource>();
    }


    public void Shake(Vector3 velocity, float strength = 1f, float duration = 0.2f,
    CinemachineImpulseDefinition.ImpulseShapes shape = CinemachineImpulseDefinition.ImpulseShapes.Explosion)
    {
        if (impulseSource == null) return;

        var def = impulseSource.ImpulseDefinition;
        def.ImpulseDuration = duration;
        def.ImpulseShape = shape;


        Vector3 finalVelocity = velocity.normalized * strength;

        impulseSource.GenerateImpulseWithVelocity(finalVelocity);
    }



}
