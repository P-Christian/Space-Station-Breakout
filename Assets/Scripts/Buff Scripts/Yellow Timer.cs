using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class YellowTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI buffTimer;
    [SerializeField] float timeLeft;
    YellowBuff yellow;
    private void Start()
    {
        yellow = GameObject.FindGameObjectWithTag("YellowTag").GetComponent<YellowBuff>();
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
            yellow.SetBehavior("true");
        }

        int seconds = Mathf.FloorToInt(timeLeft % 60);
        buffTimer.text = string.Format("{00}", seconds);
    }

    public void SetTime(float newTime)
    {
        timeLeft = newTime;
    }
}