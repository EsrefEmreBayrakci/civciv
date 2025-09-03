using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SettingsUI : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button musicButton;
    [SerializeField] private Button soundButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button mainMenuButton;

    [Header("References")]
    [SerializeField] private GameObject settingsPopup;
    [SerializeField] private GameObject blackBackground;

    [SerializeField] private CatController catController;
    [SerializeField] private catStateController catStateController;
    private catState previousState;
    private Image blackBackgroundImage;
    private bool isESC = false;

    void Awake()
    {
        blackBackgroundImage = blackBackground.GetComponent<Image>();
        settingsPopup.transform.localScale = Vector3.zero;

        pauseButton.onClick.AddListener(OnPauseButtonClicked);
        resumeButton.onClick.AddListener(OnResumeButtonClicked);

        mainMenuButton.onClick.AddListener(() =>
        {
            SceneTransition.Instance.LoadScene("MenuScene");
        });
    }

    private void Start()
    {
        catController = catController.GetComponent<CatController>();
        catStateController = catStateController.GetComponent<catStateController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isESC == false && GameManager.Instance.currentGameState != gameState.gameOver)
        {
            OnPauseButtonClicked();
            isESC = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isESC == true)
        {
            OnResumeButtonClicked();
            isESC = false;
        }

    }

    private void OnPauseButtonClicked()
    {
        GameManager.Instance.changeGameState(gameState.pause);

        if (catController != null)
        {
            previousState = catStateController.getCurrentState();
            catController.isPaused = true; // Pause modunu aktif et
            catController.changeState(catState.Idle);
        }

        settingsPopup.SetActive(true);
        blackBackground.SetActive(true);

        blackBackgroundImage.DOFade(0.8f, 0.5f).SetEase(Ease.Linear);
        settingsPopup.transform.DOScale(1.5f, 0.5f).SetEase(Ease.OutBack);
    }

    private void OnResumeButtonClicked()
    {



        blackBackgroundImage.DOFade(0f, 0.5f).SetEase(Ease.Linear);
        settingsPopup.transform.DOScale(0f, 0.5f).SetEase(Ease.OutExpo).OnComplete(() =>
        {
            GameManager.Instance.changeGameState(gameState.resume);

            if (catController != null)
            {
                catController.isPaused = false;
                catController.agent.isStopped = false;
                catController.changeState(previousState);
            }

            settingsPopup.SetActive(false);
            blackBackground.SetActive(false);
        });
    }
}
