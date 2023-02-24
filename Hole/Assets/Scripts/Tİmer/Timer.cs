using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    bool _timeisRunning;

   [SerializeField] TMP_Text timeText;

   public static float timeRemaining=5;
   

  
   

    private void Start()
    {
        _timeisRunning = true;
    }


    private void Update()
    {
        
        if (HoleMovement.timeCanStart)
        {
            TimeCheck();
        }
        if (_timeisRunning == false)
        {
          
            SceneManager.LoadScene(1);

        }
    }

    private  void TimeCheck()
    {
        if (_timeisRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                _timeisRunning = false;
            }
        }
    }
    private void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }  
}
