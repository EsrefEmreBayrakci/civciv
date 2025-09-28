using UnityEngine;
using System.Collections;
using Unity.Cinemachine;

public class FireController : MonoBehaviour
{
    [SerializeField] private GameObject fireObject;
    [SerializeField] private playerContrroller playerContrroller;


    [SerializeField] private float force;
    public float openTime = 2f;
    public float closeTime = 1f;

    private HealthManager healthManager;


    [SerializeField] private float damageCooldown = 1f;
    private bool canDamage = true;

    void Awake()
    {
        healthManager = HealthManager.Instance;
    }

    AnimationCurve explosion = new AnimationCurve(
    new Keyframe(0f, 0f),
    new Keyframe(0.1f, 1f),
    new Keyframe(0.3f, 0.2f),
    new Keyframe(1f, 0f)
);

    private void Start()
    {
        StartCoroutine(FireLoop());
    }

    private IEnumerator FireLoop()
    {
        while (true)
        {
            gameObject.transform.localScale = Vector3.one;
            fireObject.SetActive(true);
            yield return new WaitForSeconds(openTime);

            gameObject.transform.localScale = Vector3.zero;
            fireObject.SetActive(false);
            yield return new WaitForSeconds(closeTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canDamage)
        {
            healthManager.Damage(1);

            AudioManager.Instance.Play(SoundType.ChickSound);

            CameraShakeController.Instance.Shake(new Vector3(0, -1f, 0f), 1.5f, 0.3f, CinemachineImpulseDefinition.ImpulseShapes.Explosion);


            playerContrroller.getPlayerRB().AddForce(
                -playerContrroller.getPlayerTransform().forward * force,
                ForceMode.Impulse
            );

            // Cooldown başlat
            StartCoroutine(DamageCooldown());
        }
    }

    private IEnumerator DamageCooldown()
    {
        canDamage = false;
        yield return new WaitForSeconds(damageCooldown);
        canDamage = true;
    }
}
