using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class PlayerStateUI : MonoBehaviour
{
    [SerializeField] playerContrroller playerContrroller;
    private Image playerWalkingImage;
    private Image playerSlidingImage;


    [Header("References")]
    [SerializeField] RectTransform playerWalking;

    [SerializeField] RectTransform playerSliding;

    [SerializeField] RectTransform boosterSpeedTransform;
    [SerializeField] RectTransform boosterJumpTransform;
    [SerializeField] RectTransform boosterSlowTransform;

    [Header("Images")]
    [SerializeField] Image goldWheatImage;
    [SerializeField] Image holyWheatImage;

    [SerializeField] Image rottenWheatImage;




    [Header("Sprites")]
    [SerializeField] Sprite playerWalkingActiveSprite;
    [SerializeField] Sprite playerWalkingPassiveSprite;
    [SerializeField] Sprite playerSlidingActiveSprite;
    [SerializeField] Sprite playerSlidingPassiveSprite;

    [SerializeField] PlayableDirector director;

    [Header("Settings")]
    [SerializeField] float moveDuration;
    [SerializeField] Ease moveEase;

    public RectTransform getBoosterSpeedTransform() => boosterSpeedTransform;
    public RectTransform getBoosterJumpTransform() => boosterJumpTransform;
    public RectTransform getBoosterSlowTransform() => boosterSlowTransform;
    public Image getGoldWheatImage() => goldWheatImage;
    public Image getHolyWheatImage() => holyWheatImage;
    public Image getRottenWheatImage() => rottenWheatImage;

    void Awake()
    {
        playerWalkingImage = playerWalking.GetComponent<Image>();
        playerSlidingImage = playerSliding.GetComponent<Image>();
    }

    void Start()
    {
        playerContrroller.OnPlayerStateChanged += PlayerContrroller_OnStateChanged;
        director.stopped += OnPlayableDirectorStopped;

    }

    private void OnPlayableDirectorStopped(PlayableDirector director)
    {
        SetStateUserInterface(playerWalkingActiveSprite, playerSlidingPassiveSprite, playerWalking, playerSliding);
    }

    private void PlayerContrroller_OnStateChanged(playerState playerState)
    {
        switch (playerState)
        {
            case playerState.move:
            case playerState.idle:
                //üst kart
                SetStateUserInterface(playerWalkingActiveSprite, playerSlidingPassiveSprite, playerWalking, playerSliding);
                break;

            case playerState.slide:
            case playerState.slideIdle:
                //alt kart
                SetStateUserInterface(playerWalkingPassiveSprite, playerSlidingActiveSprite, playerSliding, playerWalking);
                break;


        }

    }

    private void SetStateUserInterface(Sprite playerWalkingSprite, Sprite playerSlidingSprite, RectTransform active, RectTransform passive)
    {
        playerWalkingImage.sprite = playerWalkingSprite;
        playerSlidingImage.sprite = playerSlidingSprite;

        active.DOAnchorPosX(-25f, moveDuration).SetEase(moveEase);
        passive.DOAnchorPosX(-90f, moveDuration).SetEase(moveEase);
    }

    private IEnumerator setBoosterUserInterface(RectTransform activeTransform, Image boosterImage, Image wheatImage, Sprite activeSprite, Sprite passiveSprite, Sprite activeWheatSprite, Sprite passiveWheatSprite, float duration)
    {
        boosterImage.sprite = activeSprite;
        wheatImage.sprite = activeWheatSprite;

        activeTransform.DOAnchorPosX(-120f, moveDuration).SetEase(moveEase);

        yield return new WaitForSeconds(duration);

        boosterImage.sprite = passiveSprite;
        wheatImage.sprite = passiveWheatSprite;
        activeTransform.DOAnchorPosX(-80f, moveDuration).SetEase(moveEase);
    }

    public void playBoosterUIAnimation(RectTransform activeTransform, Image boosterImage, Image wheatImage, Sprite activeSprite, Sprite passiveSprite, Sprite activeWheatSprite, Sprite passiveWheatSprite, float duration)
    {
        StartCoroutine(setBoosterUserInterface(activeTransform, boosterImage, wheatImage, activeSprite, passiveSprite, activeWheatSprite, passiveWheatSprite, duration));
    }
}

