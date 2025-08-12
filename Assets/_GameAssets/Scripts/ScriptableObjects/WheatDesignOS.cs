using UnityEngine;

[CreateAssetMenu(fileName = "WheatDesignOS", menuName = "ScriptableObjects/WheatDesignOS")]

public class WheatDesignOS : ScriptableObject
{
    public float increasDecreaseMultiplier;
    public float resetDuration;

    public Sprite passiveSprite;
    public Sprite activeSprite;

    public Sprite passiveWheatSprite;
    public Sprite activeWheatSprite;
    public float resetWheatDuration;



}
