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
    [SerializeField] GameObject componentUI;
    [SerializeField] GameObject components;
    [SerializeField] GameObject buff;
    [SerializeField] GameObject yellowTimer;
    [SerializeField] GameObject blueTimer;
    [SerializeField] GameObject slowTimer;
    

    private bool inRange = false;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Find the player's transform
        slowTimer.SetActive(false);
        buff.SetActive(false);
        components.SetActive(false);
        componentUI.SetActive(false);
        monster.SetActive(false);
        yellowTimer.SetActive(false);
        blueTimer.SetActive(false);
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
        if (other.CompareTag("Player"))
        {
            inRange = false;
            monster.SetActive(true);
            components.SetActive(true);
            componentUI.SetActive(true);
            buff.SetActive(true);
            yellowTimer.SetActive(true);
            blueTimer.SetActive(true);
            slowTimer.SetActive(true);
            Debug.Log("Player Outside Range");
        }
    }
    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.E))
        {
            
        }
    }
}