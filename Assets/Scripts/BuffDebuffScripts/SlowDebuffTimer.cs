using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SlowDebuffTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI slowTimer;
    [SerializeField] float timeLeft;
    NewBehaviourScript playerScript;
    GameObject timerUI;
    private void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<NewBehaviourScript>();
        gameObject.SetActive(true);
        timerUI = GameObject.FindGameObjectWithTag("SlowUI");

    }
    void Update()
    {
        if (timeLeft > 1)
        {
            timeLeft -= Time.deltaTime;
        }

        else if (timeLeft < 1)
        {
            
            timerUI.SetActive(false);
            playerScript.UpdateMovementSpeeds(newWalkSpeed: 8f, newRunSpeed: 13f);
        }

        int seconds = Mathf.FloorToInt(timeLeft % 60);
        slowTimer.text = string.Format("{00}", seconds);
    }

    public void SetTime(float newTime)
    {
        timeLeft = newTime;
    }
}
