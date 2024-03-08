using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Captain : MonoBehaviour
{
    private Transform playerTransform; // Reference to the player's transform
    public GameObject myObject;

    private bool inRange = false;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Find the player's transform
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
            myObject.gameObject.SetActive(false);
            Debug.Log("Player Within Range");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
            myObject.gameObject.SetActive(true);
            Debug.Log("Player Outside Range");
        }
    }
    void Update()
    {

    }
}
