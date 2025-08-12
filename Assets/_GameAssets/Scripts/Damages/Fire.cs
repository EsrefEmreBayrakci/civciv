using UnityEngine;
using System.Collections;

public class FireController : MonoBehaviour
{
    [SerializeField] private GameObject fireObject;
    [SerializeField] private playerContrroller playerContrroller;
    [SerializeField] private float force;



    private HealthManager healthManager;
    public float openTime = 2f;
    public float closeTime = 1f;

    void Awake()
    {
        healthManager = HealthManager.Instance;

    }
    private void Start()
    {

        StartCoroutine(FireLoop());
    }

    private IEnumerator FireLoop()
    {
        while (true)
        {
            gameObject.transform.localScale = Vector3.one;
            fireObject.SetActive(true);  // Aç
            yield return new WaitForSeconds(openTime);


            gameObject.transform.localScale = Vector3.zero;
            fireObject.SetActive(false); // Kapat
            yield return new WaitForSeconds(closeTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            healthManager.Damage(1);
            playerContrroller.getPlayerRB().AddForce(-playerContrroller.getPlayerTransform().forward * force, ForceMode.Impulse);

        }
    }
}
