using UnityEngine;
using UnityEngine.UI;

public class BreathRadial : MonoBehaviour
{
    [SerializeField] private GameObject breathBarRoot;
    [SerializeField] private Image breathImage;
    [SerializeField] private float drainPerSecond = 0.1f;

    private bool isUnderwater = false;

    private bool activePasive = false;

    public static BreathRadial Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (breathImage != null)
            breathImage.fillAmount = 1f;

        if (breathBarRoot != null)
            breathBarRoot.transform.localScale = Vector3.zero;
    }

    [System.Obsolete]
    private void Update()
    {
        if (isUnderwater && activePasive)
        {
            breathImage.fillAmount -= drainPerSecond * Time.deltaTime;

            if (breathImage.fillAmount <= 0f)
            {
                breathImage.fillAmount = 0f;
                HealthManager.Instance.FullDamage();

                WaterController wc = FindObjectOfType<WaterController>();
                if (wc != null)
                {
                    wc.isInWater = false;
                    breathImage.fillAmount = 1f;
                    breathBarRoot.transform.localScale = Vector3.zero;
                }

            }
        }
        else if (!isUnderwater)
        {

            breathImage.fillAmount += drainPerSecond * Time.deltaTime;
            if (breathImage.fillAmount > 1f) breathImage.fillAmount = 1f;
        }

    }

    public void SetUnderwater(bool value, bool value2)
    {
        isUnderwater = value;
        activePasive = value2;

        if (breathBarRoot != null)
            breathBarRoot.transform.localScale = value2 ? Vector3.one * 1.15f : Vector3.one * 0.01f;
    }
}

