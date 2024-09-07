using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [Header("Test Timer")]
    [SerializeField] private bool testTimer = false;
    [SerializeField] private int TestTime = 10;

    [Space(10)]
    [SerializeField] private TextMeshProUGUI timerText;

    private float timeRemaining;
    private bool isRunning;

    private void Start()
    {
        if(testTimer)
        {
            StartTimer(TestTime);
        }
    }

    private void Update()
    {
        if (isRunning)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                isRunning = false;
                TimerEnded();
            }
            DisplayTime(timeRemaining);
        }
    }

    public void StartTimer(int totalSeconds)
    {
        if(SFXManager.instance != null)
        {
            SFXManager.instance.PlayTimer();
        }
        timeRemaining = totalSeconds;
        isRunning = true;
        DisplayTime(timeRemaining);
    }

    private void DisplayTime(float timeInSeconds)
    {
        int minutes = (int)(timeInSeconds / 60);
        int seconds = (int)(timeInSeconds % 60);
        int milliseconds = (int)((timeInSeconds - (int)timeInSeconds) * 100);

        if (minutes > 0)
        {
            timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
        }
        else
        {
            timerText.text = string.Format("{0:00}:{1:00}", seconds, milliseconds);
        }
    }

    private void TimerEnded()
    {
        if (SFXManager.instance != null)
        {
            SFXManager.instance.PlayerTimerUp();
        }
        timerText.text = "Time's Up!";

        // Calls Win Condition
    }
}
