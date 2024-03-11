using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeDisplay : MonoBehaviour
{
    public TextMeshProUGUI lastSavedTimeText;
    void Start()
    {
        // Retrieve last saved time from PlayerPrefs
        float lastSavedTime = PlayerPrefs.GetFloat("SavedElapsedTime");
        // Convert saved time to minutes and seconds
        int minutes = Mathf.FloorToInt(lastSavedTime / 60);
        int seconds = Mathf.FloorToInt(lastSavedTime % 60);

        // Update UI Text with last saved time
        lastSavedTimeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        Debug.Log("Last saved time: " + lastSavedTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
