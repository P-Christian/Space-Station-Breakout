using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TimeSaver timeSaver;
    public TextMeshProUGUI lastSavedTimeText;

    float elapsedTime;
    void Update()
    {
        elapsedTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void SaveTime()
    {
        PlayerPrefs.SetFloat("SavedElapsedTime", elapsedTime);
        PlayerPrefs.Save();

        Debug.Log("Time saved: " + elapsedTime);
    }
    //Note: you have a problem with loading the time in the right format
    //The timer loading is working, just in the wrong format. seek help in blackbox for more details
    public void LoadData()
    {
        if (PlayerPrefs.HasKey("SavedElapsedTime"))
        {
            float savedElapsedTime = PlayerPrefs.GetFloat("SavedElapsedTime");

            elapsedTime = savedElapsedTime;

            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            Debug.Log("Time loaded: " + elapsedTime);
        }
        else
        {
            Debug.LogWarning("No saved time found.");
        }
    }
}
