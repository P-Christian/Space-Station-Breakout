using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class EventAnimation : MonoBehaviour
{
    SlowDebuffTimer timer;
    NewBehaviourScript playerScript;
    [SerializeField] GameObject timerUI;
    public void Hit ()
    {
        FindAnyObjectByType<HealthBar>().TakeDamage(34);
        
        timerUI.SetActive(true);
        timer = GameObject.FindGameObjectWithTag("SlowUI").GetComponentInChildren<SlowDebuffTimer>();
        timer.SetTime(16f);

        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<NewBehaviourScript>();
        if (playerScript != null)
        {
            playerScript.UpdateMovementSpeeds(newWalkSpeed: 5f, newRunSpeed: 10f);
            
        }
    }
    

}
