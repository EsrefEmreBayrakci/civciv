using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private int eggCount = 5;
    private int currentEggCount;

    [SerializeField] private TextMeshProUGUI eggCountText;

    private void Awake()
    {
        Instance = this;
    }


    public void CollectEgg()
    {
        currentEggCount++;

        if (currentEggCount == eggCount)
        {
            // renk değiştir ve animasyon
            eggCountText.color = Color.yellow;
            eggCountText.transform.DOScale(1.2f, 0.2f).OnComplete(() =>
            {
                eggCountText.transform.DOScale(1f, 0.2f);
            });

        }
        eggCountText.text = currentEggCount.ToString() + "/" + eggCount.ToString();
    }
}
