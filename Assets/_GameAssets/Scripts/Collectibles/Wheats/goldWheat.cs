using Unity.Cinemachine;
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
        AudioManager.Instance.Play(SoundType.PickupGoodSound);

        playerContrroller.setMovementSpeed(wheatDesignOS.increasDecreaseMultiplier, wheatDesignOS.resetDuration);
        PlayerStateUI.playBoosterUIAnimation(boosterTransform, boosterImage, PlayerStateUI.getGoldWheatImage(), wheatDesignOS.activeSprite, wheatDesignOS.passiveSprite, wheatDesignOS.activeWheatSprite, wheatDesignOS.passiveWheatSprite, wheatDesignOS.resetDuration);

        CameraShakeController.Instance.Shake(new Vector3(-0.3f, -0f, 0f), 0.5f, 1f, CinemachineImpulseDefinition.ImpulseShapes.Bump);

        gameObject.SetActive(false);

        Invoke(nameof(ActiveWheat), wheatDesignOS.resetWheatDuration);
    }

    private void ActiveWheat()
    {
        gameObject.SetActive(true);
    }
}
