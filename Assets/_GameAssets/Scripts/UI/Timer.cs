using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    [SerializeField] private GameObject rotateble;
    private float time;


    private float rotateAngle;
    bool timerIsRunning = false;

    private void Start()
    {

        timerIsRunning = true;
        rotateAngle = 6f * Time.timeScale; // 360 degrees / 60 seconds = 6 degrees per second
    }

    private void Update()
    {
        if (GameManager.Instance.currentGameState != gameState.play && GameManager.Instance.currentGameState != gameState.resume)
        {
            return;
        }

        timer();

    }

    private void timer()
    {
        if (timerIsRunning)
        {
            time += Time.deltaTime;

            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time % 60);
            timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");

            rotateble.transform.Rotate(0, 0, -rotateAngle * Time.deltaTime);

        }
    }

    public float getTime()
    {
        return time;
    }



}
