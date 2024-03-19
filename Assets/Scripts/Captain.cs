using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Captain : MonoBehaviour
{
    public string interactText = "Press E to interact";
    private Transform playerTransform; // Reference to the player's transform
    [SerializeField] GameObject monster;
    [SerializeField] GameObject monsterTwo;
    [SerializeField] GameObject componentUI;
    [SerializeField] GameObject components;
    [SerializeField] GameObject buff;
    [SerializeField] GameObject yellowTimer;
    [SerializeField] GameObject blueTimer;
    [SerializeField] GameObject slowTimer;
    [SerializeField] GameObject missionUpdate;
    [SerializeField] GameObject dialogueTrigger;
    public Timer timer;
    

    private bool inRange = false;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Find the player's transform
        slowTimer.SetActive(false);
        buff.SetActive(false);
        components.SetActive(false);
        componentUI.SetActive(false);
        monster.SetActive(false);
        monsterTwo.SetActive(false);
        yellowTimer.SetActive(false);
        blueTimer.SetActive(false);
        missionUpdate.SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
            
            Debug.Log("Player Within Range");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == GameObject.FindGameObjectWithTag("Player"))
        {
            inRange = false;
            monster.SetActive(true);
            monsterTwo.SetActive(true);
            components.SetActive(true);
            componentUI.SetActive(true);
            missionUpdate.SetActive(false);
            dialogueTrigger.SetActive(false);
            buff.SetActive(true);
            yellowTimer.SetActive(true);
            blueTimer.SetActive(true);
            slowTimer.SetActive(true);
            timer.StartTime();
            Debug.Log("Player Outside Range");
        }
    }
}