using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    // REf: https://gamedevbeginner.com/how-to-make-countdown-timer-in-unity-minutes-seconds/
    float timeRemaining;
    public bool timerIsRunning = false;
    public Text timeText;

    private void Start()
    {
        //timeRemaining = PlayerPrefs.GetFloat("initialGamingTime");
        timeRemaining = 180;//testning

        // Starts the timer automatically
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
            DisplayTime(timeRemaining);
        }
    }

    /// <summary>
    /// Extracts minutes and seconds from deltatime
    /// </summary>
    /// <param name="timeToDisplay"></param>
    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void IncreaseTimer(float secondsToAdd)
    {
        timeRemaining += secondsToAdd;
    }
}
