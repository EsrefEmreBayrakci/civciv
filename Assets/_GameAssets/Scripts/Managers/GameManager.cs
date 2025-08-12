using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public event Action<gameState> OnGameStateChanged;

    [SerializeField] private int eggCount = 5;
    private int currentEggCount;

    [SerializeField] private TextMeshProUGUI eggCountText;
    public gameState currentGameState;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        changeGameState(gameState.play);
    }


    public void changeGameState(gameState gameState)
    {

        OnGameStateChanged?.Invoke(gameState);
        currentGameState = gameState;

        switch (currentGameState)
        {
            case gameState.play:
                // Oyun başladığında yapılacaklar
                break;
            case gameState.pause:
                // Oyun duraklatıldığında yapılacaklar

                break;
            case gameState.resume:
                // Oyun devam ettiğinde yapılacaklar

                break;
            case gameState.gameOver:
                // Oyun bittiğinde yapılacaklar
                break;
        }
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
                GameManager.Instance.changeGameState(gameState.gameOver);
                WinLoseUI.Instance.WinUI();
            });


        }
        eggCountText.text = currentEggCount.ToString() + "/" + eggCount.ToString();
    }
}
