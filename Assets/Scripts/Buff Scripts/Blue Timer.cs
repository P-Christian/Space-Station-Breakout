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
    private void Start()
    {
        blue = GameObject.FindGameObjectWithTag("BlueTag").GetComponent<BlueBuff>();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<NewBehaviourScript>();
        gameObject.SetActive(true);

    }
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
        }

        else if (timeLeft < 0)
        {
            timeLeft = 0;
            playerScript.UpdateMovementSpeeds(newWalkSpeed: 12f, newRunSpeed: 18f);
        }

        int seconds = Mathf.FloorToInt(timeLeft % 60);
        buffTimer.text = string.Format("{00}", seconds);
    }

    public void SetTime(float newTime)
    {
        timeLeft = newTime;
    }
}