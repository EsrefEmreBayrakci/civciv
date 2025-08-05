using UnityEngine;

public class playerInteractionController : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.TryGetComponent<ICollectible>(out var collectible))
        {
            collectible.collect();
        }


    }



}
