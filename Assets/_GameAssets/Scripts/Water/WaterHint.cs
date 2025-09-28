using UnityEngine;
using TMPro;
using DG.Tweening; // DoTween namespace

public class WaterHint : MonoBehaviour
{
    [SerializeField] private Transform bubbleRoot;
    [SerializeField] private GameObject Arrow;

    [SerializeField] private float triggerDistance = 5f;

    [SerializeField] private float animationDuration = 0.3f;

    private bool isVisible = false;
    private Transform player;

    private void Start()
    {
        if (bubbleRoot != null)
            bubbleRoot.localScale = Vector3.zero;

        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    private void Update()
    {

        GameObject[] waters = GameObject.FindGameObjectsWithTag("Water");

        bool nearWater = false;
        foreach (var water in waters)
        {
            float dist = Vector3.Distance(player.position, water.transform.position);
            if (dist < triggerDistance)
            {
                nearWater = true;
                break;
            }
        }

        if (nearWater && !isVisible)
            ShowBubble();
        else if (!nearWater && isVisible)
            HideBubble();
    }

    private void ShowBubble()
    {
        isVisible = true;
        bubbleRoot.DOScale(Vector3.one * 0.1f, animationDuration).SetEase(Ease.OutBack);
        Arrow.SetActive(false);
    }

    private void HideBubble()
    {
        isVisible = false;
        bubbleRoot.DOScale(Vector3.zero, animationDuration).SetEase(Ease.InBack);
        Arrow.SetActive(true);
    }
}
