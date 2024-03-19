using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlueTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI buffTimer;
    [SerializeField] float timeLeft;
    BlueBuff blue;
    NewBehaviourScript playerScript;
    GameObject timerUI;
    private void Start()
    {
        
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<NewBehaviourScript>();
        timerUI = GameObject.FindGameObjectWithTag("BlueTimeTag");
        blue = GameObject.FindGameObjectWithTag("BlueTag").GetComponent<BlueBuff>();
        gameObject.SetActive(true);

    }
    void Update()
    {
        
        if (timeLeft > 1)
        {
            timeLeft -= Time.deltaTime;
        }

        else if (timeLeft < 1)
        {
            timeLeft = 0;
            timerUI.SetActive(false);
            playerScript.UpdateMovementSpeeds(newWalkSpeed: 8f, newRunSpeed: 13f);
        }

        int seconds = Mathf.FloorToInt(timeLeft % 60);
        buffTimer.text = string.Format("{00}", seconds);
    }

    public void SetTime(float newTime)
    {
        timeLeft = newTime;
    }
}