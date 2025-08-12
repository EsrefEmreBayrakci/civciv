using UnityEngine;
using UnityEngine.UI;

public class rottenWheat : MonoBehaviour, ICollectible
{

    [SerializeField] playerContrroller playerContrroller;
    [SerializeField] WheatDesignOS wheatDesignOS;

    [SerializeField] PlayerStateUI PlayerStateUI;

    private RectTransform boosterTransform;
    private Image boosterImage;


    void Awake()
    {
        boosterTransform = PlayerStateUI.getBoosterSlowTransform();
        boosterImage = boosterTransform.GetComponent<Image>();
    }
    public void collect()
    {
        playerContrroller.setMovementSpeed(wheatDesignOS.increasDecreaseMultiplier, wheatDesignOS.resetDuration);
        PlayerStateUI.playBoosterUIAnimation(boosterTransform, boosterImage, PlayerStateUI.getRottenWheatImage(), wheatDesignOS.activeSprite, wheatDesignOS.passiveSprite, wheatDesignOS.activeWheatSprite, wheatDesignOS.passiveWheatSprite, wheatDesignOS.resetDuration);
        gameObject.SetActive(false);

        Invoke(nameof(ActiveWheat), wheatDesignOS.resetWheatDuration);
    }

    private void ActiveWheat()
    {
        gameObject.SetActive(true);
    }
}
