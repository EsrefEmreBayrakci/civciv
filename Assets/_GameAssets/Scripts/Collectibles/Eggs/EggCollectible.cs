using UnityEngine;

public class EggCollectible : MonoBehaviour, ICollectible
{



    public void collect()
    {
        GameManager.Instance.CollectEgg();
        Destroy(gameObject);
    }
}
