using UnityEngine;
using UnityEngine.UI;

public class goldWheat : MonoBehaviour, ICollectible
{
    [SerializeField] playerContrroller playerContrroller;

    [SerializeField] WheatDesignOS wheatDesignOS;

    [SerializeField] PlayerStateUI PlayerStateUI;

    private RectTransform boosterTransform;
    private Image boosterImage;



    void Awake()
    {
        boosterTransform = PlayerStateUI.getBoosterSpeedTransform();
        boosterImage = boosterTransform.GetComponent<Image>();

    }


    public void collect()
    {


        playerContrroller.setMovementSpeed(wheatDesignOS.increasDecreaseMultiplier, wheatDesignOS.resetDuration);
        PlayerStateUI.playBoosterUIAnimation(boosterTransform, boosterImage, PlayerStateUI.getGoldWheatImage(), wheatDesignOS.activeSprite, wheatDesignOS.passiveSprite, wheatDesignOS.activeWheatSprite, wheatDesignOS.passiveWheatSprite, wheatDesignOS.resetDuration);



        Destroy(gameObject);
    }
}
