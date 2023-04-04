using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    

    [Header("Component")]
    public GameObject MainMenuUI;
    
    public GameObject GameViewUI;
    public TextMeshProUGUI GameViewTime;
    
    public GameObject PauseMenuUI;
    public TextMeshProUGUI PauseMenuTime;
    public TextMeshProUGUI PMBestTime;
    
    public GameObject GameOverUI;
    public TextMeshProUGUI GameOverTime;
    public TextMeshProUGUI GOBestTime;

    [Header("Timer Settings")]
    public float currentTime;
    public float bestTime;
    public bool countDown;
    string bestTimeKey = "BestTime";

    [Header("Limit Settings")]
    public bool hasLimit;
    public float timerLimit;
    public bool GameIsPaused = false;
    public bool TimeIsLoaded = false;
    public bool TimeIsSaved = false;

    private void Start()
    {
        //bestTime = 0;
    }



    private void Update()
    {
        
        currentTime = countDown ? currentTime -= Time.deltaTime : currentTime += Time.deltaTime;

        if(hasLimit && ((countDown && currentTime <= timerLimit) || (!countDown && currentTime >= timerLimit)))
        {
            currentTime = timerLimit;
            SetCurrentTimerText();
            enabled = false;
        }

        SetCurrentTimerText();
        SetBestTimerText();

        if (MainMenuUI.activeInHierarchy)
        {
            Time.timeScale = 0f;
            currentTime = 0;
            countDown = false;
        }
        if(GameViewUI.activeInHierarchy)
        {
            Time.timeScale = 1f;
            GameIsPaused = false;
            countDown = false;
        }
        if(PauseMenuUI.activeInHierarchy)
        {
            Time.timeScale = 0f;
            GameIsPaused = true;
            countDown = false;
            LoadBestTime();
            SetBestTimerText();
        }
        if(GameOverUI.activeInHierarchy)
        {
            Time.timeScale = 0f;
            GameIsPaused = true;
            countDown = true;
            
            if (currentTime > bestTime)
            {
            bestTime = currentTime;
            
            SaveBestTime();

            }
            
            if (currentTime <= bestTime)
            {
            
            LoadBestTime();
            
            }
            
            
        }
        


    }

    private void SetCurrentTimerText()
    {
        float minutes = Mathf.FloorToInt(currentTime / 59);
        float seconds = Mathf.FloorToInt(currentTime % 59);
                
        GameViewTime.text = string.Format("{00:00}:{01:00}", minutes, seconds);
        PauseMenuTime.text = GameViewTime.text;
        GameOverTime.text = GameViewTime.text;
                    
    }
    private void SetBestTimerText()
    {
        float minutes = Mathf.FloorToInt(bestTime / 59);
        float seconds = Mathf.FloorToInt(bestTime % 59);

        GOBestTime.text = string.Format("{00:00}:{01:00}", minutes, seconds);
        PMBestTime.text = GOBestTime.text;
    }
    public void SaveBestTime()
    {
        
        if (TimeIsSaved == false)
        {
            PlayerPrefs.SetFloat(bestTimeKey, currentTime);
            PlayerPrefs.Save();

            TimeIsSaved = true;
        }
        
    }

    public void LoadBestTime()
    {
        if (TimeIsLoaded == false)
        {
            bestTime = PlayerPrefs.GetFloat(bestTimeKey, 0);

            TimeIsLoaded = true;
        }
    }
   
}
