using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    private int currentHealth;
    [SerializeField] private GameObject[] healthIcons;

    [SerializeField] Sprite activeHealthSprite;
    [SerializeField] Sprite passiveHealthSprite;


    public static HealthManager Instance { get; private set; }


    void Awake()
    {
        Instance = this;

        SceneManager.sceneLoaded += (scene, mode) =>
   {
       healthIcons = new GameObject[3];

       healthIcons[2] = GameObject.FindGameObjectWithTag("RightIcon");
       healthIcons[1] = GameObject.FindGameObjectWithTag("MiddleIcon");
       healthIcons[0] = GameObject.FindGameObjectWithTag("LeftIcon");



       currentHealth = maxHealth;
       UpdateHealthIcons();
   };
    }



    private void Start()
    {
        healthIcons = new GameObject[3];

        healthIcons[2] = GameObject.FindGameObjectWithTag("RightIcon");
        healthIcons[1] = GameObject.FindGameObjectWithTag("MiddleIcon");
        healthIcons[0] = GameObject.FindGameObjectWithTag("LeftIcon");


        currentHealth = maxHealth;
        UpdateHealthIcons();
    }

    [System.Obsolete]
    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;


        UpdateHealthIcons();


        if (currentHealth <= 0)
        {
            currentHealth = 0;
            GameManager.Instance.changeGameState(gameState.gameOver);
            WinLoseUI.Instance.LoseUI();

        }
    }

    public void Heal(int healAmount)
    {
        int oldHealth = currentHealth;
        currentHealth = Mathf.Clamp(currentHealth + healAmount, 0, maxHealth);

        if (currentHealth != oldHealth)
        {
            UpdateHealthIcons();
        }
    }




    private void UpdateHealthIcons()
    {
        for (int i = 0; i < healthIcons.Length; i++)
        {
            if (healthIcons[i] == null) continue;

            if (i < currentHealth)
            {
                Image img = healthIcons[i].GetComponent<Image>();

                img.sprite = activeHealthSprite;
                img.color = new Color(1f, 1f, 1f, 0f);
                img.transform.localScale = Vector3.zero;

                img.DOFade(1f, 0.3f);
                img.transform.DOScale(Vector3.one, 0.4f).SetEase(Ease.OutBack);

            }
            else
            {
                Image img = healthIcons[i].GetComponent<Image>();

                img.sprite = passiveHealthSprite;
                img.color = new Color(1f, 1f, 1f, 0f);
                img.transform.localScale = Vector3.zero;

                img.DOFade(1f, 0.3f);
                img.transform.DOScale(Vector3.one, 0.4f).SetEase(Ease.OutBack);

            }
        }

    }

    [System.Obsolete]
    public void FullDamage()
    {
        currentHealth = 0;
        UpdateHealthIcons();
        GameManager.Instance.changeGameState(gameState.gameOver);
        WinLoseUI.Instance.LoseUI();
    }
}