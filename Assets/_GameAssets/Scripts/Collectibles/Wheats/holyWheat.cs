using UnityEngine;
using UnityEngine.UI;

public class holyWheat : MonoBehaviour, ICollectible
{

    [SerializeField] playerContrroller playerContrroller;
    [SerializeField] WheatDesignOS wheatDesignOS;

    [SerializeField] PlayerStateUI PlayerStateUI;

    private RectTransform boosterTransform;
    private Image boosterImage;

    void Awake()
    {
        boosterTransform = PlayerStateUI.getBoosterJumpTransform();
        boosterImage = boosterTransform.GetComponent<Image>();
    }

    public void collect()
    {

        playerContrroller.setJumpForce(wheatDesignOS.increasDecreaseMultiplier, wheatDesignOS.resetDuration);
        PlayerStateUI.playBoosterUIAnimation(boosterTransform, boosterImage, PlayerStateUI.getHolyWheatImage(), wheatDesignOS.activeSprite, wheatDesignOS.passiveSprite, wheatDesignOS.activeWheatSprite, wheatDesignOS.passiveWheatSprite, wheatDesignOS.resetDuration);

        gameObject.SetActive(false);

        Invoke(nameof(ActiveWheat), wheatDesignOS.resetWheatDuration);
    }

    private void ActiveWheat()
    {
        gameObject.SetActive(true);
    }

}
