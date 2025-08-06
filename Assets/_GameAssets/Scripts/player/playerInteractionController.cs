using UnityEngine;

public class playerInteractionController : MonoBehaviour
{
    private playerContrroller playerContrroller;

    void Awake()
    {
        playerContrroller = GetComponent<playerContrroller>();
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.TryGetComponent<ICollectible>(out var collectible))
        {
            collectible.collect();
        }


    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<IBoostable>(out var boostable))
        {
            boostable.Boost(playerContrroller);

        }
    }



}
