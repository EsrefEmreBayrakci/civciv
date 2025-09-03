using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinLoseUI : MonoBehaviour
{
    [SerializeField] private GameObject winUI;
    [SerializeField] private TextMeshProUGUI winText;
    [SerializeField] private GameObject loseUI;
    [SerializeField] private TextMeshProUGUI loseText;
    [SerializeField] private GameObject blackBackground;
    [SerializeField] private GameObject timer;

    [SerializeField] private Button MainMenuButton;
    [SerializeField] private Button MainMenuButton2;

    private float time;


    public static WinLoseUI Instance { get; private set; }

    private void Awake()
    {
        Instance = this;

        MainMenuButton.onClick.AddListener(() =>
        {
            SceneTransition.Instance.LoadScene("MenuScene");
        });

        MainMenuButton2.onClick.AddListener(() =>
        {
            SceneTransition.Instance.LoadScene("MenuScene");
        });
    }

    void Update()
    {
        time = timer.GetComponent<Timer>().getTime();
    }

    public void WinUI()
    {
        winUI.SetActive(true);
        winUI.transform.DOScale(Vector3.one, 0.2f).OnComplete(() =>
        {
            blackBackground.SetActive(true);
            blackBackground.GetComponent<Image>().DOFade(0.8f, 0.3f).SetEase(Ease.Linear);
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time % 60);
            winText.text = minutes.ToString("00") + ":" + seconds.ToString("00");

            //Time.timeScale = 0;
        });

    }

    public void LoseUI()
    {
        loseUI.SetActive(true);
        loseUI.transform.DOScale(Vector3.one, 0.2f).OnComplete(() =>
        {
            blackBackground.SetActive(true);
            blackBackground.GetComponent<Image>().DOFade(0.8f, 0.3f).SetEase(Ease.Linear);
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time % 60);
            loseText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        });

    }


    public void onTryAgainButtonClicked()
    {
        //Time.timeScale = 1;
        winUI.SetActive(false);
        loseUI.SetActive(false);
        blackBackground.SetActive(false);
        winUI.transform.localScale = Vector3.zero;
        loseUI.transform.localScale = Vector3.zero;
        SceneManager.LoadScene("GameScene");
    }

}
