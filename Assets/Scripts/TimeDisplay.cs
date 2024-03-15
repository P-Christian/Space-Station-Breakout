using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeDisplay : MonoBehaviour
{
    public TextMeshProUGUI lastSavedTimeText;
    void Start()
    {
        int gameFinished = 2000;
        // Retrieve last saved time from PlayerPrefs
        int lastSavedTime = PlayerPrefs.GetInt("SavedElapsedTime");
        // Convert saved time to minutes and seconds
        int score = gameFinished - lastSavedTime;

        // Update UI Text with last saved time
        lastSavedTimeText.text = score.ToString();

        Debug.Log("Last saved time: " + lastSavedTime);
    }

}
