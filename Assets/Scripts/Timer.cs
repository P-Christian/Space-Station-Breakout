using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TimeSaver timeSaver;

    float elapsedTime;

    void Start()
    {
        timerText.gameObject.SetActive(false);
    }
    void Update()
    {
        elapsedTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StartTime()
    {
        elapsedTime = 0;
        timerText.gameObject.SetActive(true);
    }

    public void SaveTime()
    {
        int roundedTime = Mathf.RoundToInt(elapsedTime); // Round elapsedTime to the nearest whole number
        PlayerPrefs.SetInt("SavedElapsedTime", roundedTime); // Save the rounded time as an integer
        PlayerPrefs.Save();

        Debug.Log("Time saved: " + roundedTime);
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
