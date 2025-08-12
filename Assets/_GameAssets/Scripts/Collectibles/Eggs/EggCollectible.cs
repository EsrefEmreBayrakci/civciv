using UnityEngine;

public class EggCollectible : MonoBehaviour, ICollectible
{
    private bool isCollected = false;

    public void collect()
    {
        if (isCollected) return; // zaten toplandıysa tekrar işlemi engelle

        isCollected = true;
        Destroy(gameObject);
        GameManager.Instance.CollectEgg();
    }


}
