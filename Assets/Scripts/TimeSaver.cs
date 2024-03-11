using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSaver : MonoBehaviour
{
    public Timer timer;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            timer.SaveTime();
        }
    }
    public void SaveTime()
    {
        timer.SaveTime();
    }
}
