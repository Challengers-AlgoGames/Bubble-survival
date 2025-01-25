using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public static event System.Action OnTimerOut;

    private float timerDuration = 60f;
    private float timeRemaining;
    private bool isTimeRunning = false;

    public Text timerText;

    private void Awake()
    {
        UIManager.OnStartGame += StartTimer;
    }

    private void OnDestroy()
    {
        UIManager.OnStartGame -= StartTimer;
    }


    private void Update()
    {
        if (isTimeRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimeDisplay(timeRemaining);
            }
            else
            {
                Debug.Log("Termine");
                timeRemaining = 0;
                isTimeRunning = false;
                OnTimerOut?.Invoke();
            }
        }
    }

    private void UpdateTimeDisplay(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    private void StartTimer()
    {
        timeRemaining = timerDuration;
        isTimeRunning = true;
        Debug.Log("Timer démarré !");
    }
}
