using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControllerUI : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button quitButton;


    void Awake()
    {
        playButton.onClick.AddListener(() =>
        {
            SceneTransition.Instance.LoadScene("GameScene");
        });

        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }

}
