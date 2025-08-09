using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HealtManager : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    private int currentHealth;
    [SerializeField] private GameObject[] healthIcons;

    [SerializeField] Sprite activeHealthSprite;
    [SerializeField] Sprite passiveHealthSprite;





    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthIcons();
    }





    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;
        // Animasyon yapılabilir

        UpdateHealthIcons();


        if (currentHealth <= 0)
        {
            currentHealth = 0;
            // işlemler burada yapılabilir

        }
    }

    public void Heal(int healAmount)
    {
        int oldHealth = currentHealth;
        currentHealth = Mathf.Clamp(currentHealth + healAmount, 0, maxHealth);

        if (currentHealth != oldHealth)
        {
            UpdateHealthIcons(); // Sadece değişiklik varsa animasyon uygula
        }
    }




    private void UpdateHealthIcons()
    {
        for (int i = 0; i < healthIcons.Length; i++)
        {
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

    public void FullDamage()
    {
        currentHealth = 0;
        UpdateHealthIcons();
    }
}