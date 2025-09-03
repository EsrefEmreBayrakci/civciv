using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition Instance;

    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 1f;

    private void Awake()
    {
        // Singleton
        if (Instance == null) Instance = this;
        else { Destroy(gameObject); return; }

        DontDestroyOnLoad(gameObject);
        fadeImage.color = new Color(0, 0, 0, 0); // Başlangıçta görünmez
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(Transition(sceneName));
    }

    private IEnumerator Transition(string sceneName)
    {
        // Fade Out (ekran kararıyor)
        yield return fadeImage.DOFade(1f, fadeDuration).WaitForCompletion();

        // Sahneyi yükle
        yield return SceneManager.LoadSceneAsync(sceneName);

        // Fade In (ekran açılıyor)
        yield return fadeImage.DOFade(0f, fadeDuration).WaitForCompletion();
    }
}
